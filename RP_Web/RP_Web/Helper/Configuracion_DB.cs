using System;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using RP_Web.Models;
using System.Collections.Generic;

namespace RP_Web.Helper
{
    //Herencia 
    public class Configuracion_DB:ListModel
    {
        //Conexion a Base Datos;
        string conexionString = ConfigurationManager.ConnectionStrings["RPM_DB"].ConnectionString;
        // Metodo para validar Conexion
        public bool conexion()
        {
            bool cn = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conexionString))
                {
                    con.Open();
                    con.Close();
                    cn = true;
                }
            }
            catch (Exception e)
            {
                cn = false;
                Console.WriteLine("Error ", e);
            }

            return cn;
        }
        //

        //Login 
        public List<UsuarioPermisosModel> ValidarLogin(string user, string pass)
        {
            //------------------------------------------------------------------------        
            string v = "";
            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_login_users", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        v = dr["nombre"].ToString();
                        Upm.Add(new UsuarioPermisosModel()
                        {
                            Nombre_usuario = dr["Nombre"].ToString(),
                            Email = dr["Correo"].ToString(),
                            //Roll = dr["roll"].ToString(),
                            Permisos = dr["PerfilId"].ToString(),
                        });
                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error ", e);
                }
            }
            return Upm;
        }

        //SP Para recuperar las credenciales del usuario
        public List<UsuarioInfo> RecuperaCredenciales(string email)
        {
            var ret = new List<UsuarioInfo>();                
            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_recuperar_credenciales", conn); //SP para recuperar credenciales
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user", email);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ret.Add(new UsuarioInfo()
                        {
                            Nombre_usuario = dr["Nombre"].ToString(),
                            Email = dr["Correo"].ToString(),
                            Passwords = dr["Pass"].ToString()
                        });
                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error ", e);
                }
            }
            return ret;
        }
        
        //Agregar nuevo usuario
        public List<NuevoUsuario> RegistroUsuarios(string user,string email, string cel, string pass)
        {
            var ret = new List<NuevoUsuario>();
            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_new_user", conn); //SP para registrar usuarios
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Datos que va guardar la base de datos
                    cmd.Parameters.AddWithValue("@name", user);
                    cmd.Parameters.AddWithValue("@user", email);
                    cmd.Parameters.AddWithValue("@cel", cel);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ret.Add(new NuevoUsuario()
                        {
                            Nombre_usuario = dr["Nombre"].ToString(),
                            Email = dr["Correo"].ToString(),
                            Celular = dr["Celular"].ToString(),
                            Passwords = dr["Pass"].ToString()
                        });
                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error ", e);
                }
            }
            return ret;
        }

        //Agregar uan reservacion
        public List<Reservacion> NuevaReservacion(string nombre, string personas, string hora, string fecha)
        {
            var ret = new List<Reservacion>();
            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_reservar", conn); //SP para registrar usuarios
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Datos que va guardar la base de datos
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    //cmd.Parameters.AddWithValue("@lugar", lugar);
                    cmd.Parameters.AddWithValue("@pers", personas);
                    cmd.Parameters.AddWithValue("@hora", hora);
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ret.Add(new Reservacion()
                        {
                            Nombre_reserva = dr["NombrePersona"].ToString(),
                            //Lugar = dr["LugarReservaId"].ToString(),
                            Personas = dr["NumPersonas"].ToString(),
                            Hora = dr["HoraReserva"].ToString(),
                            Fecha = dr["FechaReserva"].ToString()
                        });
                    }
                    conn.Close();
                }
                catch (Exception e) 
                {
                    Console.WriteLine("Error ", e); //Error
                }
            }
            return ret;
        }

        //Mostrar Lista Mesa
        public List<MesaModel> ListaMesas()
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_catalogo_mes", conn); //SP para registrar usuarios
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Datos que va guardar la base de datos
                    //cmd.Parameters.AddWithValue("@name", user);
                    //cmd.Parameters.AddWithValue("@user", email);
                    //cmd.Parameters.AddWithValue("@cel", cel);
                    //cmd.Parameters.AddWithValue("@pass", pass);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListMesa.Add(new MesaModel()
                        {
                            MesaId = dr["MesaId"].ToString(),
                            LugarReservaId = dr["LugarReservaId"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                        });
                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error ", e);
                }
            }
            return ListMesa;
        }

        //Mostrar Clasificacion
        public List<ClasModel> ListaClasificacion()
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_catalogo_clasif", conn); //SP para registrar usuarios
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Datos que va guardar la base de datos
                    //cmd.Parameters.AddWithValue("@name", user);
                    //cmd.Parameters.AddWithValue("@user", email);
                    //cmd.Parameters.AddWithValue("@cel", cel);
                    //cmd.Parameters.AddWithValue("@pass", pass);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListClas.Add(new ClasModel()
                        {
                            ClasificacionId = dr["ClasificacionId"].ToString(),
                            Habilitado = dr["Habilitado"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                        });
                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error ", e);
                }
            }
            return ListClas;
        }

        //Mostrar Establecimiento
        public List<EstaModel> ListaEstablecimiento()
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_catalogo_establ", conn); //SP para registrar usuarios
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Datos que va guardar la base de datos
                    //cmd.Parameters.AddWithValue("@name", user);
                    //cmd.Parameters.AddWithValue("@user", email);
                    //cmd.Parameters.AddWithValue("@cel", cel);
                    //cmd.Parameters.AddWithValue("@pass", pass);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListEsta.Add(new EstaModel()
                        {
                            LugarReservaId = dr["LugarReservaId"].ToString(),
                            ClasificacionId = dr["ClasificacionId"].ToString(),
                            NombreLugar = dr["NombreLugar"].ToString(),
                            Ubicacion = dr["Ubicacion"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Habilitado = dr["Habilitado"].ToString(),
                        });
                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error ", e);
                }
            }
            return ListEsta;
        }

        //------------------------------------------------------------------------------------------------------------------------//

        //Mostrar Area
        public List<AreaModel> ListaArea()
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_catalogo_area", conn); //SP para registrar usuarios
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Datos que va guardar la base de datos
                    //cmd.Parameters.AddWithValue("@name", user);
                    //cmd.Parameters.AddWithValue("@user", email);
                    //cmd.Parameters.AddWithValue("@cel", cel);
                    //cmd.Parameters.AddWithValue("@pass", pass);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListArea.Add(new AreaModel()
                        {
                            AreaId = dr["AreaId"].ToString(),
                            Habilitado = dr["Habilitado"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                        });
                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error ", e);
                }
            }
            return ListArea;
        }

        //------------------------------------------------------------------------------------------------------------------------//

        //Actualizar  Mesa
        public List<MesaModel> MesaUpdate(string Query, int IDMesa, string Lugar, string Descripcion)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_mesa_ins_up", conn); //SP para registrar usuarios
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Datos que va guardar la base de datos
                    cmd.Parameters.AddWithValue("@Query", Query);
                    cmd.Parameters.AddWithValue("@IDMesa", IDMesa);
                    cmd.Parameters.AddWithValue("@Lugar", Lugar);
                    cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListMesa.Add(new MesaModel()
                        {
                            MesaId = dr["MesaId"].ToString(),
                            LugarReservaId = dr["LugarReservaId"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                        });
                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error ", e);
                }
            }
            return ListMesa;
        }

        //Insertas Datos Mesa
        public List<MesaModel> MesaInsert(string Query, int IDMesa, string Lugar, string Descripcion)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_mesa_ins_up", conn); //SP para registrar usuarios
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Datos que va guardar la base de datos
                    cmd.Parameters.AddWithValue("@Query", Query);
                    cmd.Parameters.AddWithValue("@IDMesa", IDMesa);
                    cmd.Parameters.AddWithValue("@Lugar", Lugar);
                    cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListMesa.Add(new MesaModel()
                        {
                            MesaId = dr["MesaId"].ToString(),
                            LugarReservaId = dr["LugarReservaId"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                        });
                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error ", e);
                }
            }
            return ListMesa;
        }

        //------------------------------------------------------------------------------------------------------------------------//

        //Insertar Datos Establecimiento
        public List<EstaModel> EstablecimientoInsert(string Query, int LugarReservaId, string ClasificacionId, string NombreLugar, string Ubicacion, string Telefono, string Correo, string Habilitado)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_establecimiento_ins_up", conn); //SP para registrar usuarios
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Datos que va guardar la base de datos
                    cmd.Parameters.AddWithValue("@Query", Query);
                    cmd.Parameters.AddWithValue("@LugarReservaId", LugarReservaId);
                    cmd.Parameters.AddWithValue("@ClasificacionId", ClasificacionId);
                    cmd.Parameters.AddWithValue("@NombreLugar", NombreLugar);
                    cmd.Parameters.AddWithValue("@Ubicacion", Ubicacion);
                    cmd.Parameters.AddWithValue("@Telefono", Telefono);
                    cmd.Parameters.AddWithValue("@Correo", Correo);
                    cmd.Parameters.AddWithValue("@Habilitado", Habilitado);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ListEsta.Add(new EstaModel()
                        {
                            LugarReservaId = dr["LugarReservaId"].ToString(),
                            NombreLugar = dr["NombreLugar"].ToString(),
                            ClasificacionId = dr["ClasificacionId"].ToString(),
                            Ubicacion = dr["Ubicacion"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Habilitado = dr["Habilitado"].ToString(),
                        });
                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error ", e);
                }
            }
            return ListEsta;
        }

        //Actualizar Datos Establecimiento
        public List<EstaModel> EstablecimientoUpdate(string Query, int LugarReservaId, string ClasificacionId, string NombreLugar, string Ubicacion, string Telefono, string Correo, string Habilitado)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_establecimiento_ins_up", conn); //SP para registrar usuarios
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Datos que va guardar la base de datos
                    cmd.Parameters.AddWithValue("@Query", Query);
                    cmd.Parameters.AddWithValue("@LugarReservaId", LugarReservaId);
                    cmd.Parameters.AddWithValue("@ClasificacionId", ClasificacionId);
                    cmd.Parameters.AddWithValue("@NombreLugar", NombreLugar);
                    cmd.Parameters.AddWithValue("@Ubicacion", Ubicacion);
                    cmd.Parameters.AddWithValue("@Telefono", Telefono);
                    cmd.Parameters.AddWithValue("@Correo", Correo);
                    cmd.Parameters.AddWithValue("@Habilitado", Habilitado);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        /*
                        ListEsta.Add(new EstaModel()
                        {
                            LugarReservaId = dr["LugarReservaId"].ToString(),
                            NombreLugar = dr["NombreLugar"].ToString(),
                            ClasificacionId = dr["ClasificacionId"].ToString(),
                            Ubicacion = dr["Ubicacion"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Habilitado = dr["Habilitado"].ToString(),
                        });*/
                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error ", e);
                }
            }
            return ListEsta;
        }

        //------------------------------------------------------------------------------------------------------------------------//

        //Actualizar Datos Area
        public List<AreaModel> AreaUpdate(string Query, int AreaId, string Descripcion, string Habilitado)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_area_ins_up", conn); //SP para registrar usuarios
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Datos que va guardar la base de datos
                    cmd.Parameters.AddWithValue("@Query", Query);
                    cmd.Parameters.AddWithValue("@AreaId", AreaId);
                    cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                    cmd.Parameters.AddWithValue("@Habilitado", Habilitado);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        /*
                        ListEsta.Add(new EstaModel()
                        {
                            LugarReservaId = dr["LugarReservaId"].ToString(),
                            NombreLugar = dr["NombreLugar"].ToString(),
                            ClasificacionId = dr["ClasificacionId"].ToString(),
                            Ubicacion = dr["Ubicacion"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Habilitado = dr["Habilitado"].ToString(),
                        });*/
                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error ", e);
                }
            }
            return ListArea;
        }

        //Insertar Datos Area
        public List<AreaModel> AreaInsert(string Query, int AreaId, string Descripcion, string Habilitado)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_area_ins_up", conn); //SP para registrar usuarios
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Datos que va guardar la base de datos
                    cmd.Parameters.AddWithValue("@Query", Query);
                    cmd.Parameters.AddWithValue("@AreaId", AreaId);
                    cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                    cmd.Parameters.AddWithValue("@Habilitado", Habilitado);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        
                        ListArea.Add(new AreaModel()
                        {
                            //AreaId = dr["AreaId"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            Habilitado = dr["Habilitado"].ToString(),
                        });
                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error ", e);
                }
            }
            return ListArea;
        }

        //------------------------------------------------------------------------------------------------------------------------//

        //Insertar Datos Clasificacion
        public List<ClasModel> ClasificacionInsert(string Query,int ClasificacionId, string Descripcion, int Habilitado)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_clasificacion_ins_up", conn); //SP para registrar usuarios
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Datos que va guardar la base de datos
                    cmd.Parameters.AddWithValue("@Query", Query);
                    cmd.Parameters.AddWithValue("@ClasificacionId", ClasificacionId);
                    cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                    cmd.Parameters.AddWithValue("@Habilitado", Habilitado);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        ListClas.Add(new ClasModel()
                        {
                            //AreaId = dr["AreaId"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            Habilitado = dr["Habilitado"].ToString(),
                        });
                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error ", e);
                }
            }
            return ListClas;
        }

        //Actualizar Datos Clasificacion
        public List<ClasModel> ClasificacionUpdate(string Query, int ClasificacionId, string Descripcion, int Habilitado)
        {
            using (SqlConnection conn = new SqlConnection(conexionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_clasificacion_ins_up", conn); 

                    cmd.CommandType = CommandType.StoredProcedure;

                    //Datos que va guardar la base de datos
                    cmd.Parameters.AddWithValue("@Query", Query);
                    cmd.Parameters.AddWithValue("@ClasificacionId", ClasificacionId);
                    cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                    cmd.Parameters.AddWithValue("@Habilitado", Habilitado);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        ListClas.Add(new ClasModel()
                        {
                            ClasificacionId = dr["ClasificacionId"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            Habilitado = dr["Habilitado"].ToString(),
                        });
                    }
                    conn.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error ", e);
                }
            }
            return ListClas;
        }


    }
}
