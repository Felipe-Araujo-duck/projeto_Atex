using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Atex
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            TextoInicio.Text= "Bem-vindo ao Nosso Mundo Digital Colorido! 🌈📱\r\n\r\nOlá, aventureiro(a) digital!\r\n\r\nEstamos muito felizes em ter você e seu amiguinho(a) aqui! Este é um espaço especial, criado para que \r\njuntos vocês compartilhem um pouco mais sobre o dia a dia digital.\r\nQueremos saber quais são os jogos favoritos, as redes sociais que curtem e tudo mais que faz parte dessa experiência online!\r\nEste questionário é como um mapa mágico que nos ajudará a entender melhor como as crianças exploram o universo digital, com a \r\najuda dos adultos que as acompanham.\r\nNão se preocupe, não vai levar muito tempo, e será uma experiência divertida para ambos!\r\n\r\n🚀 Aperte o botão abaixo para começar a nossa jornada!";
            TextoFim.Text = "Adultos, vocês são os guias nessa aventura! Fiquem à vontade para auxiliar seus pequenos exploradores nas respostas, e juntos vamos \r\ndescobrir mais sobre esse mundo digital colorido.\r\nSe surgir alguma dúvida, não hesitem em chamar o adulto legal para ajudar.\r\nEstamos ansiosos para conhecer mais sobre o mundo digital da criançada! 🌟\r\nAté logo!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.FC = new cadastro();
            Program.FC.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Relatorios FR = new Relatorios();
            FR.ShowDialog();
        }

        private void TextoInicio_Click(object sender, EventArgs e)
        {

        }
    }
}
