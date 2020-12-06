using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;


namespace winformsCrud_proyecto
{
    public partial class TIENDA_ALQUILER_BIENVENIDO : Form
    {
        private IconButton currentBtn;
        private Panel lefBordenBtn;
        private Form currentchildform;
        public TIENDA_ALQUILER_BIENVENIDO()
        {
            InitializeComponent();
            lefBordenBtn = new Panel();
            lefBordenBtn.Size = new Size(7, 60);
            panelmenu.Controls.Add(lefBordenBtn);
            
        }
        private struct BRGColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(0, 0, 64);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //borde button
                lefBordenBtn.BackColor = color;
                lefBordenBtn.Location = new Point(0, currentBtn.Location.Y);
                lefBordenBtn.Visible = true;
                lefBordenBtn.BringToFront();
                //icono
                iconoHijoform1.IconChar = currentBtn.IconChar;
                iconoHijoform1.IconColor = color;



            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void iconbtndatospersona_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, BRGColors.color2);
            OpenFormchildren(new formdatosPersonales() );
            //formdatosPersonales frm = new formdatosPersonales();
            //frm.ShowDialog();
        }

        private void iconbtnDatosPelicula_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, BRGColors.color1);
            OpenFormchildren(new frmDatosPeli());
        }

        private void botonInicio_Click(object sender, EventArgs e)
        {
            currentchildform.Close();
            Reset();
        }
        private void Reset()
        {

            DisableButton();
            lefBordenBtn.Visible = false;
            iconoHijoform1.IconChar = IconChar.Home;
            iconoHijoform1.IconColor =Color.Fuchsia;
            lblInicio.Text = "Inicio";
        }
        private void OpenFormchildren(Form childform)
        {
            if (currentchildform != null)
            {
                currentchildform.Close();
            }
            currentchildform = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            panelEscritorio.Controls.Add(currentchildform);
            panelEscritorio.Tag = currentchildform;
            currentchildform.BringToFront();
            currentchildform.Show();
            lblInicio.Text = currentchildform.Text;




        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }
    }
}
