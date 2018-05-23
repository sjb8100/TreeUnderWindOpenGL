using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace TreeForDen
{
    public class TexturesForObjects
    {
        public TexturesForObjects()
        {

        }
        // имя текстуры 
        private string texture_name = "";
        // ее ID 
        private int imageId = 0;
        // идентификатор текстуры в памяти openGL 
        private uint mGlTextureObject = 0;
        // получение этого идентификатора 
        public uint GetTextureObj()
        {
            return mGlTextureObject;
        }
        // загрузка текстуры 
        public void LoadTextureForModel(string FileName)
        { // запоминаем имя файла 
            texture_name = FileName;
            // создаем изображение с идентификатором  imageId 
            Il.ilGenImages(1, out imageId);
            // делаем изображение текущим 
            Il.ilBindImage(imageId); string url = "";
            // получаем адрес текущей директории 
            url = Directory.GetCurrentDirectory(); url += "";
            // добавляем имя текстуры 
            url += texture_name;
            // если загрузка удалась 
            if (Il.ilLoadImage(url))
            {
                // если загрузка прошла успешно 
                // сохраняем размеры изображения 
                int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);
                // определяем число бит на пиксель 
                int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);
                switch (bitspp)
                // в зависимости от полученного результата 
                {
                    // создаем текстуру используя режим GL_RGB или GL_RGBA 
                    case 24: mGlTextureObject = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                        break;
                    case 32: mGlTextureObject = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                        break;
                }
                // очищаем память 
                Il.ilDeleteImages(1, ref imageId);
            }
        }
        // создание текстуры в памяти openGL 
        private static uint MakeGlTexture(int Format, IntPtr pixels, int w, int h)
        {
            // идентификатор текстурного объекта 
            uint texObject;
            // генерируем текстурный объект 
            Gl.glGenTextures(1, out texObject);
            // устанавливаем режим упаковки пикселей 
            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);
            // создаем привязку к только что созданной текстуре 
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texObject);
            // устанавливаем режим фильтрации и повторения текстуры 
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_REPLACE);
            // создаем RGB или RGBA текстуру 
            switch (Format)
            {
                case Gl.GL_RGB:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, w, h, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;
                case Gl.GL_RGBA: Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, w, h, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;
            }
            // возвращаем идентификатор текстурного объекта 
            return texObject;
        }
    }
}
