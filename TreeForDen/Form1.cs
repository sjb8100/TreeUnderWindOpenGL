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

        double ScreenW, ScreenH;
        private float devX;
        private float devY;

        private float[,] GrapValuesArray;
        private int element_count = 0;
        private bool not_calculate = true;

        private int pointPosition = 0;
        float lineX, lineY;


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

            //если одно значение, то это будет точка
            //два значения - одно начальное, другое конечное
            //по ним рисуется линия

            Gl.glVertex2d(15, 0);
            Gl.glVertex2d(15, 5);


            for (int i =0;i<10;i++)
            {
                Gl.glVertex2d(14 -i, 6+i);
            }

            //drawTree(15, 10);

            //завершаем режим рисования
            Gl.glEnd();
            //дожидаемся конца визуализации
            Gl.glFlush();
            //посылаем сигнал перерисовки элемента
            SOGIControl.Invalidate();
        }

        private float[] drawTree(float x1, float y1)
        {
            float[] ArrayOfXY = new float[2];
                ArrayOfXY[0] = x1;
                ArrayOfXY[1] = y1;

                if (x1>1 && y1<29)
                {
                    //float x2 = (float)(x1 - Math.Cos(20));
                    //float y2 = (float)(y1 + Math.Cos(20));

                    float x2 = x1 - 1;
                    float y2 = y1 + 1;

                    Gl.glVertex2d(x2, y2);
                    ArrayOfXY[0] = x2;
                    ArrayOfXY[1] = y2;

                return ArrayOfXY;

                }
                else
                {
                    ArrayOfXY[0] = float.MinValue;
                    ArrayOfXY[1] = float.MinValue;
                    return ArrayOfXY;
                }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //pointlgrap


        }
    }
}
