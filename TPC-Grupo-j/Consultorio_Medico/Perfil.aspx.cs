using dominio;
using negocio;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using helpers;

namespace Consultorio_Medico
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected int rol { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Session.Add("editable", false);
                    rol = Session["Rol"] != null ? (int)Session["Rol"] : -1;
                    System.Diagnostics.Debug.WriteLine(rol);

                    if (Seguridad.ValidarUsuario(Session["usuario"]))
                    {
                        Usuario user = (Usuario)Session["usuario"];
                        string imagePath = Server.MapPath("~/Images/img_perfil/" + user.img_url);
                        RecNegocio negocio_rec = new RecNegocio();
                        switch (rol)
                        {
                            case 1:
                                txtbEmail.Text = user.email;
                                txtbFecha.Text = user.fecha_creacion.ToString("dd/MM/yyyy");
                                txtbRol.Text = user.rol_type.ToString();
                                if (!string.IsNullOrEmpty(user.img_url) && File.Exists(imagePath))
                                {
                                    imgPerfil.ImageUrl = "~/Images/img_perfil/" + user.img_url;
                                }
                                break;
                            case 2:
                                Recepcionista recepcionista = negocio_rec.buscarRecepcionista(user);
                                txtbEmail.Text = recepcionista.email;
                                txtbFecha.Text = recepcionista.fecha_creacion.ToString("dd/MM/yyyy");
                                txtbRol.Text = recepcionista.rol_type.ToString();
                                txtbNombre.Text = recepcionista.nombre;
                                txtbApellido.Text = recepcionista.apellido;
                                txtbNacimiento.Text = recepcionista.nacimiento.ToString("dd/MM/yyyy");
                                if (!string.IsNullOrEmpty(recepcionista.img_url) && File.Exists(imagePath))
                                {
                                    imgPerfil.ImageUrl = "~/Images/img_perfil/" + user.img_url;
                                }

                                break;
                            case -1:
                                break;

                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Seguridad.ManejarExcepcion(ex, HttpContext.Current);
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                RecNegocio recepcionistaNegocio = new RecNegocio();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                Usuario user = (Usuario)Session["usuario"];
                if (fileupd.HasFile)
                {
                    string ruta = Server.MapPath("~/Images/img_perfil/");
                    string fileName = "imgPerfil-" + user.id + ".jpg";
                    string filePath = Path.Combine(ruta, fileName);

                    fileupd.SaveAs(filePath);

                    user.img_url = fileName;
                }
                switch (user.rol_type)
                {
                    case UserRole.Admin:
                        usuarioNegocio.actualizar(user);
                        break;
                    case UserRole.Recepcionista:
                        Recepcionista recepcionista = new Recepcionista(user);
                        recepcionista.nombre = txtbNombre.Text;
                        recepcionista.apellido = txtbApellido.Text;
                        recepcionista.nacimiento = DateTime.Parse(txtbNacimiento.Text);
                        recepcionistaNegocio.actualizar(recepcionista);
                        break;
                    case UserRole.Null:
                        Response.Redirect("Login.aspx");
                        break;
                }

                imgPerfil.ImageUrl = "~/Images/img_perfil/" + user.img_url;

                Image imgAvatar = (Image)Master.FindControl("imgAvatar");
                if (imgAvatar != null)
                {
                    imgAvatar.ImageUrl = "~/Images/img_perfil/" + user.img_url;
                }
                Response.Redirect("Perfil.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if ((int)Session["Rol"] == 1)
            {
                // Mensaje de depuración para verificar si la condición se cumple
                System.Diagnostics.Debug.WriteLine("El rol es 1, se permite la edición.");
                System.Diagnostics.Debug.WriteLine("Valor de on_edit pri: " + Session["editable"].ToString());


                if ((bool)Session["editable"] == false)
                {
                    btnEditar.Text = "Cancelar";
                    btnGuardar.Visible = true;
                    Session["editable"] = true;
                    System.Diagnostics.Debug.WriteLine("Valor de on_edit dentro de if: " + Session["editable"].ToString());
                    
                }
                else
                {
                    btnGuardar.Visible = false;
                    btnEditar.Text = "Editar Perfil";
                    Session["editable"] = false;
                    System.Diagnostics.Debug.WriteLine("Valor de on_edit dentro de else: " + Session["editable"].ToString());
   
                }
            }
            else
            {
                if ((bool)Session["editable"] == false)
                {
                    txtbNombre.Enabled = true;
                    txtbApellido.Enabled = true;
                    txtbNacimiento.Enabled = true;
                    btnGuardar.Visible = true;
                    btnEditar.Text = "Cancelar";
                    fileupd.Enabled = true;
                    Session["editable"] = true;
                    System.Diagnostics.Debug.WriteLine("Valor de on_edit: " + Session["editable"].ToString());
                }
                else
                {
                    txtbNombre.Enabled = false;
                    txtbApellido.Enabled = false;
                    txtbNacimiento.Enabled = false;
                    btnGuardar.Visible = false;
                    btnEditar.Text = "Editar Perfil";
                    fileupd.Enabled = false;
                    Session["editable"] = false;
                    System.Diagnostics.Debug.WriteLine("Valor de on_edit: " + Session["editable"].ToString());
                }
            }

        }

    }

}

