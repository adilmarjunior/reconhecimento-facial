using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace FaceDetection
{
    public partial class Form1 : Form
    {
        MCvFont font = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_TRIPLEX, 0.6d, 0.6d);
        HaarCascade faceDetected;
        Image<Bgr, byte> Frame;
        Capture camera;
        Image<Gray, byte> resultado;
        Image<Gray, byte> TrainedFace = null;
        Image<Gray, byte> grayFace = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> usuarios = new List<string>();
        int Count, NumLables, t;

        private void btnIniciaDetection_Click(object sender, EventArgs e)
        {
            camera = new Capture();
            camera.QueryFrame();
            Application.Idle += new EventHandler(FrameProcedure);
        }

        private void FrameProcedure(object sender, EventArgs e)
        {
            usuarios.Add("");
            Frame = camera.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            grayFace = Frame.Convert<Gray, byte>();
            MCvAvgComp[][] facesDetectedNow = grayFace.DetectHaarCascade(faceDetected, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20,20));

            foreach (var face in facesDetectedNow[0])
            {
                resultado = Frame.Copy(face.rect).Convert<Gray, byte>().Resize(100,100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                Frame.Draw(face.rect, new Bgr(Color.Green), 3);

                if (trainingImages.ToArray().Length != 0)
                {
                    MCvTermCriteria termCriterias = new MCvTermCriteria(Count, 0.001);
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(trainingImages.ToArray(), labels.ToArray(), 1500, ref termCriterias);
                    nome = recognizer.Recognize(resultado);
                    Frame.Draw(nome, ref font, new Point(face.rect.X-2, face.rect.Y-2), new Bgr(Color.Red));
                }

                //usuarios[t - 1] = nome;
                usuarios.Add("");
            }

            cameraBox.Image = Frame;
            nomes = "";
            usuarios.Clear();

        }

        private void btnSalvarRosto_Click(object sender, EventArgs e)
        {
            Count = Count + 1;
            grayFace = camera.QueryGrayFrame().Resize(320,240,Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            MCvAvgComp[][] DetectedFaces = grayFace.DetectHaarCascade(faceDetected, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20,20));

            foreach (var face in DetectedFaces[0])
            {
                TrainedFace = Frame.Copy(face.rect).Convert<Gray, byte>();
                break;
            }

            TrainedFace = resultado.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            trainingImages.Add(TrainedFace);
            labels.Add(txtNome.Text);
            File.WriteAllText(Application.StartupPath + "/Faces/Faces.txt", trainingImages.ToArray().Length.ToString() + ",");

            for (int i = 1; i < trainingImages.ToArray().Length+1; i++)
            {
                trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/Faces/face" + i + ".bmp");
                File.AppendAllText(Application.StartupPath + "/Faces/Faces.txt", labels.ToArray()[i - 1] + ",");
            }

            MessageBox.Show(txtNome.Text + " adicionado com sucesso!");
        }

        string nome, nomes = null;

        public Form1()
        {
            InitializeComponent();

            faceDetected = new HaarCascade("haarcascade_frontalface_default.xml");

            try
            {
                string linhasArquivo = File.ReadAllText(Application.StartupPath+"/Faces/Faces.txt");
                string[] linhas = linhasArquivo.Split(',');

                NumLables = Convert.ToInt16(linhas[0]);

                Count = NumLables;

                string FacesLoad;

                for (int i = 0; i < NumLables; i++)
                {
                    FacesLoad = "face" + i + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/Faces/Faces.txt"));
                    labels.Add(linhas[i]);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Rosto não encontrado na base de dados");
            }
        }
    }
}
