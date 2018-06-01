using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace TreeForDen
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            SOGIControl.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // инициализация Glut 
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            // отчитка окна 
            Gl.glClearColor(255, 255, 255, 1);
            // установка порта вывода в соответствии с размерами элемента anT 
            Gl.glViewport(0, 0, SOGIControl.Width, SOGIControl.Height);
            // настройка проекции 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            
            if ((float)SOGIControl.Width <= (float)SOGIControl.Height)
            {
                Glu.gluOrtho2D(0.0, 30.0 * (float)SOGIControl.Height / (float)SOGIControl.Width, 0.0, 30.0);
            }
            else
            {
                Glu.gluOrtho2D(0.0, 30.0 * (float)SOGIControl.Width / (float)SOGIControl.Height, 0.0, 30.0);
            }

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }

        private void SOGIControl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glColor3f(255, 0, 0);

            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glVertex2d(2, 6);

            //завершаем режим рисования
            Gl.glEnd();
            //дожидаемся конца визуализации
            Gl.glFlush();
            //посылаем сигнал перерисовки элемента
            SOGIControl.Invalidate();

        }

        private void drawTree()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
