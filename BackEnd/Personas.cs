using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public class Personas
    {
        public Persona[] ListaPersona;

        public DataTable lista_persona { get; set; } = new DataTable();

        public Personas()
        {
            lista_persona.Rows.Add();
            lista_persona.TableName = "Lista_Personas";
            lista_persona.Columns.Add("ID", typeof(int));
            lista_persona.Columns.Add("DNI", typeof(string));
            lista_persona.Columns.Add("Nombre", typeof(string));
            lista_persona.Columns.Add("Apellido", typeof(string));
            lista_persona.Columns.Add("Edad", typeof(int));
            lista_persona.Columns.Add("CUIL", typeof(string));
            lista_persona.Columns.Add("FechaNac", typeof(DateTime));
            ReadDataListFile();
        }

        public void ReadDataListFile()
        {
            if (System.IO.File.Exists("DataList.xml"))
            {
                lista_persona.ReadXml("DataList.xml");
            }
        }
        
        public int GenerarID()
        {
            int ID = 0;
            int ListLength;
            if (ListaPersona == null)
            { 
                ListLength = 1;
            }
            else
            {
                ListLength = ListaPersona.Length+1;
            }
            
            for (int i = 0; i <  ListLength; i++)
            {
                if (ListaPersona[i] == null)
                {
                    lista_persona.Rows[i]["ID"] = DBNull.Value;
                }
                else
                {
                    ID = i;
                }
            }
            return ID;
        }
           
        public void InsertPersona(Persona aPersona)
        {
            int ID = NuevoID();

            lista_persona.Rows.Add(); //agrego renglon vacio

            int NuevoRenglon = lista_persona.Rows.Count - 1;
            lista_persona.Rows[NuevoRenglon]["ID"] = ID;
            lista_persona.Rows[NuevoRenglon]["DNI"] = aPersona.DNI;
            lista_persona.Rows[NuevoRenglon]["Nombre"] = aPersona.Nombre;
            lista_persona.Rows[NuevoRenglon]["Apellido"] = aPersona.Apellido;
            lista_persona.Rows[NuevoRenglon]["Edad"] = aPersona.Edad;
            lista_persona.Rows[NuevoRenglon]["CUIL"] = aPersona.CUIL;
            lista_persona.Rows[NuevoRenglon]["FechaNac"] = aPersona.FechaNac;
            lista_persona.WriteXml("DataList.xml");
        }

        private int NuevoID()
        {
            int NuevoId = 0;

            foreach (DataRow fila in lista_persona.Rows)
            {

                if (fila["ID"] != DBNull.Value)
                {
                    if (NuevoId < Convert.ToInt32(fila["ID"]))
                    {
                        NuevoId = Convert.ToInt32(fila["ID"]);
                    }
                }

            }

            NuevoId++;
            return NuevoId;
        }

        /* public void InventoryScan()
          {

              for (int i = 0; i < ListaPersona.Length; i++)
              {

                  int Position;

                  lista_persona.Rows.Add();

                  if (ListaPersona[i] == null)
                  {
                      lista_persona.Rows[i]["ID"] = DBNull.Value;
                  }
                  else
                  {
                      Position = i;
                      lista_persona.Rows[i]["ID"] = i;
                  }
              }

              lista_persona.WriteXml("DataList.xml");
          } */

        /* public Persona Buscar(string aId)
         {
             int id = Convert.ToInt32(aId);

             Persona per = new Persona();

             foreach (DataRow fila in lista_persona.Rows)
             {
                 if (Convert.ToInt32(fila["ID"]) == id)
                 {
                     per.ID = Convert.ToInt32(fila["ID"]);
                     per.Nombre = Convert.ToString(fila["Nombre"]);
                     per.Apellido = fila["Apellido"].ToString();
                     per.Edad = Convert.ToInt32(fila["Edad"]);
                     break;
                 }
             }


             return per;
         }*/
    }
}
