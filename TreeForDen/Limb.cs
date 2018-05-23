using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeForDen
{
    // класс LIMB отвечает за логические единицы 3D объектов в загружаемой сцене 
    public class LIMB 
    { 
    // при инициализации мы должны указать количество вершин (vertex) и полигонов 
    // (face) которые описывают геометрию подобъекта 
    public LIMB( int a, int b)
        { if (temp[0] == 0) temp[0] = 1;
        // записываем количество вершин и полигонов 
        VandF[0] = a; VandF[1] = b;
        // выделяем память 
        memcompl();
    } public int Itog;
        // флаг успешности 
        // массивы для хранения данных (геометрии и текстурных координат) 
        public float[,] vert;
        public int[,] face;
        public float[,] t_vert;
        public int[,] t_face; // номер материала (текстуры) данного подобъекта 
        public int MaterialNom = -1; // временное хранение информации 
        public int[] VandF = new int[4];
        private int[] temp = new int[2];
        // флаг, говорящий о том, что модель использует текстуру 
        private bool ModelHasTexture = false ;
        // функция для определения значения флага (о наличии текстуры) 
        public bool NeedTexture()
        { // возвращаем значение флага 
            return ModelHasTexture;
        } // массивы для текстурных координат 
        public void createTextureVertexMem( int a)
        {
            VandF[2] = a;
            t_vert = new float[3, VandF[2]];
        }
        // привязка значений текстурных координат к полигонам 
        public void createTextureFaceMem( int b)
        {
            VandF[3] = b;
            t_face = new int[3, VandF[3]]; // отмечаем флаг о наличии текстуры 
            ModelHasTexture = true;
        } // память для геометрии 
        private void memcompl()
        {
            vert = new float[3, VandF[0]];
            face = new int[3, VandF[1]];
        } // номер текстуры 
        public int GetTextureNom()
        {
            return MaterialNom;
        }
    };
    // данный класс относился к немного другой реализации, будем считать его заготовкой реализации на будущее 
    public class Model_Prop
    {
        public Model_Prop()
        {
            pos_abs[0] = 0;
            pos_abs[1] = 0;
            pos_abs[2] = 0;
            maximum[0] = 0;
            maximum[1] = 0;
            maximum[2] = 0;
            minimum[0] = 0;
            minimum[1] = 0;
            minimum[2] = 0;
            rotating_angles[0] = 0;
            rotating_angles[1] = 0;
            rotating_angles[2] = 0;
        }
        public float[] pos_abs = new float[3];
        public float[] maximum = new float[3];
        public float[] minimum = new float[3];
        public float[] rotating_angles = new float[3];
    }; 

}
