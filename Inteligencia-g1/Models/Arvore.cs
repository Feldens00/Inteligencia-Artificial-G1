using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Inteligencia_g1.Models
{
    public class Arvore
    {

        public static float[,]  matrizImg1 = new float[100,100]; //matriz que armazena a outra lista que contem  os  valores padroes da imagem
        public static float[,] matrizImg2= new float[100,100];
        public static float[,] pesos = new float[100, 100];

        public static float v = 1;
        public static float soma;
        public static float w0 = 0;

        #region Matriz para valores

        public static void FotoWork()
        {
            List<float> listaPreto = new List<float>();
            List<float> listaBranco = new List<float>();
            float escala = 0;
            string imgOriginal = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/Pictures/arvore.png";
            Bitmap img = new Bitmap(imgOriginal, true);
            Bitmap novaFoto = new Bitmap(img.Width, img.Height);

            float largura = img.Width /100;
            float comprimento = img.Height /100;
            for (int p = 0; p < 100; p++)
            {
                for (int p2 = 0; p2 < 100; p2++)
                {
                    for (int i = (p * (int)largura); i < ((p+1) * (int)largura); i++)
                    {
                        for (int x = (p2 * (int)comprimento); x < (p2 * (int)largura); x++)
                        {
                            Color corOriginal = img.GetPixel(i, x);
                            escala = (int)((corOriginal.R * 0.3) + (corOriginal.G * 0.59) + (corOriginal.B * 0.11));//escala de cinza
                            if (escala > 0 && escala <= 110)
                            {

                                listaPreto.Add(0);
                            }
                            if (escala > 110 && escala < 256)
                            {
                                listaBranco.Add(1);
                            }

                        }
                    }
                    if (listaPreto.Count() > listaBranco.Count())
                    {
                        matrizImg1[p, p2] = 0;
                    }
                    if (listaBranco.Count() > listaPreto.Count())
                    {
                        matrizImg1[p, p2] = 1;
                    }
                    listaPreto.Clear();
                    listaBranco.Clear();


                }
            }
           /*
            string imgOriginal2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Pictures\arvore34.png";
            Bitmap img2 = new Bitmap(imgOriginal2, true);
            Bitmap novaFoto2 = new Bitmap(img2.Width, img2.Height);

            for (int x = 0; x < img2.Width; x++)
            {
                for (int y = 0; y < img2.Height; y++)
                {
                    Color CorOrigina2 = img2.GetPixel(x, y);
                    int escala2 = (int)((CorOrigina2.R * 0.3) + (CorOrigina2.G * 0.59) + (CorOrigina2.B * 0.11));
                    if (escala2 > 0 && escala2 <= 110)
                    {

                        listaByte2.Add(0);
                    }
                    if (escala2 >= 110 && escala2 < 256)
                    {
                        listaByte2.Add(1);
                    }
                    Color escalaCinza = Color.FromArgb(escala2, escala2, escala2);
                    novaFoto2.SetPixel(x, y, escalaCinza);
                }
            }


            listaCompleta1 = listaByte1;

            listaCompleta2 = listaByte2;

            for (int x = 0; x < 10000; x++)
            {
                pesos.Add(0);
            }*/

        }
        #endregion

        #region Treinamento/Aprendizado

       /* public static void Aprendizado()
        {
            float y1 = 1;  //saida
            float y2 = 0;  //saida
            float yDesejado = 0; //saida desejada
            int cont = 0;
            soma = 0;
            
            while (cont != 2)
            {

                cont = 0;
               
                for (int x = 0; x < 10000; x++)
                {
                    soma += (listaCompleta1[x] * pesos[x]);
                }
                soma += (v * w0);

                if (soma <= 0)
                {
                    yDesejado = 0;
                }
                if (soma > 0)
                {
                    yDesejado = 1;
                }
                if (yDesejado != y1)
                {

                    for (int x = 0; x < 10000; x++)
                    {
                        pesos[x] = pesos[x] + 1 * (y1 - yDesejado) * listaCompleta1[x];
                    }
                    w0 = w0 + 1 * (y1 - yDesejado) * v;
                }
                else
                {
                    cont++;
                }
                
                for (int x = 0; x < 10000; x++)
                {
                    soma += (listaCompleta2[x] * pesos[x]);
                }
                soma += (v * w0);

                if (soma <= 0)
                {
                    yDesejado = 0;
                }
                if (soma > 0)
                {
                    yDesejado = 1;
                }
                if (yDesejado != y2)
                {
                    for (int x = 0; x < 10000; x++)
                    {
                        pesos[x] = pesos[x] + 1 * (y2 - yDesejado) * listaCompleta2[x];
                    }
                    w0 = w0 + 1 * (y2 - yDesejado) * v;
                }
                else
                {
                    cont++;
                }
  
            }
            
        }*/
        #endregion


        public static List<float> Retorno()
        {
            List<float> listaByte = new List<float>();
            

            string imgOriginal3 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/Pictures/arvore.png";
            Bitmap img3 = new Bitmap(imgOriginal3, true);
            Bitmap newFoto = new Bitmap(img3.Width, img3.Height);

            for (int i = 0; i < img3.Width; i++)
            {
                for (int x = 0; x < img3.Height; x++)
                {
                    Color cor = img3.GetPixel(i, x);
                    int escala = (int)((cor.R * 0.3) + (cor.G * 0.59) + (cor.B * 0.11));//escala de cinza
                    if (escala > -1 && escala <= 110)
                    {

                        listaByte.Add(0);
                    }
                    if (escala >= 110 && escala < 256)
                    {
                        listaByte.Add(1);
                    }
                    Color escalaCinza3 = Color.FromArgb(escala, escala, escala);
                    newFoto.SetPixel(i, x, escalaCinza3);
                    

                }
            }
                newFoto.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Pictures\arvore2.png");
                return listaByte;
            
        }
        public static  void RetornoMatriz()
        {
            List<float> listaPreto = new List<float>();
            List<float> listaBranco = new List<float>();
            float escala = 0;
            string imgOriginal = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/Pictures/placa.png";
            Bitmap img = new Bitmap(imgOriginal, true);
            Bitmap novaFoto = new Bitmap(img.Width, img.Height);

            float largura = img.Width / 100;
            float comprimento = img.Height / 100;
            for (int p = 0; p < 100; p++)
            {
                for (int p2 = 0; p2 < 100; p2++)
                {
                    for (int i = (p * (int)largura); i < ((p + 1) * (int)largura); i++)
                    {
                        for (int x = (p2 * (int)comprimento); x < ((p2+1) * (int)comprimento); x++)
                        {
                            Color corOriginal = img.GetPixel(i, x);
                            escala = (int)((corOriginal.R * 0.3) + (corOriginal.G * 0.59) + (corOriginal.B * 0.11));//escala de cinza
                            if (escala >= 0 && escala <= 130)
                            {

                                listaPreto.Add(0);
                            }
                            if (escala > 130 && escala < 256)
                            {
                                listaBranco.Add(1);
                            }

                        }
                    }
                    if (listaPreto.Count() > listaBranco.Count())
                    {
                        matrizImg1[p2, p] = 0;
                    }
                    if (listaBranco.Count() > listaPreto.Count())
                    {
                        matrizImg1[p2, p] = 1;
                    }
                    listaPreto.Clear();
                    listaBranco.Clear();


                }
            }
            
        }

        #region Teste

       /* public static float Teste(List<float> Binario)
        {
            float y = 0; //saida
            float soma = 0;

            for (int x = 0; x < 10000; x++)
            {
                soma += (Binario[x] * pesos[x]);
            }
            soma += (v * w0);

            if (soma <= 0)
            {
                y = 0;
            }
            if (soma > 0)
            {
                y = 1;
            }
            return y;
        }
        */

        #endregion


    }

   

    

}