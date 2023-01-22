using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace WindowsFormsApplication1
{
    public partial class login : Form
    {
        public SpeechRecognitionEngine recognitionengine;
       
        int second = 0;
        int min = 0;
        int hour = 0;
        public login()
        {
            InitializeComponent();
            recognitionengine = new SpeechRecognitionEngine();
            recognitionengine.SetInputToDefaultAudioDevice();
           
        }
        public Grammar letterGrammar()
        {
            GrammarBuilder letterGb = new GrammarBuilder();
            Choices letterChoices = new Choices("enable");


            GrammarBuilder spellingGb = new GrammarBuilder((GrammarBuilder)letterChoices, 1, 50);

            Grammar grammar = new Grammar(spellingGb);

            return grammar;

        }
        public Grammar letterGrammar1()
        {
            GrammarBuilder letterGb1 = new GrammarBuilder();
            Choices letterChoices1 = new Choices("1", "2", "3", "4", "5", "6", "7", "8", "9", "0");


            GrammarBuilder spellingGb1 = new GrammarBuilder((GrammarBuilder)letterChoices1, 1, 50);

            Grammar grammar1 = new Grammar(spellingGb1);

            return grammar1;

        }
        public Grammar letterGrammar2()
        {
            GrammarBuilder letterGb2= new GrammarBuilder();
            Choices letterChoices2 = new Choices( "login");


            GrammarBuilder spellingGb2 = new GrammarBuilder((GrammarBuilder)letterChoices2, 1, 50);

            Grammar grammar2= new Grammar(spellingGb2);

            return grammar2;

        }

        private void login_Load(object sender, EventArgs e)
        {
            
                
            recognitionengine.SpeechRecognized += (s, args) =>
            {
                foreach (RecognizedWordUnit word1 in args.Result.Words)
                {
                    textBox3.Text = word1.Text;
                    /* if (word.Confidence > 0.8f)
                     {*/

                    if (word1.Text.Equals("enable"))
                  
                    {

                        radioButton1.Select();
                        recognitionengine.RecognizeAsyncStop();
                        call();
                       //callforid();
                        //callforpwd();
                    }
                    
                    


                }

            };

            Grammar cg = letterGrammar();

            recognitionengine.LoadGrammar(cg);
            recognitionengine.RecognizeAsync(RecognizeMode.Multiple);

        }
        int len = 5;
        private void callforid()
        {
            
            recognitionengine.SpeechRecognized += (s, args) =>
            {
                foreach (RecognizedWordUnit word1 in args.Result.Words)
                {
                    textBox3.Text = word1.Text;
                    for (int i = 0; i < len; i++)
                        textBox1.Text = textBox1.Text + word1.Text;
                    recognitionengine.RecognizeAsyncStop();
                    callforpwd();
                }

            };

            Grammar cg1 = letterGrammar1();

            recognitionengine.LoadGrammar(cg1);
            recognitionengine.RecognizeAsync(RecognizeMode.Multiple);
         
        }
        private void callforpwd()
        {

            recognitionengine.SpeechRecognized += (s, args) =>
            {
                
                foreach (RecognizedWordUnit word1 in args.Result.Words)
                {
                    textBox3.Text = word1.Text;
                    for (int i = 0; i < len; i++)
                        textBox2.Text = textBox2.Text + word1.Text;
                    recognitionengine.RecognizeAsyncStop();
                    call();
                   
                }

            };

            Grammar cg1 = letterGrammar1();

            recognitionengine.LoadGrammar(cg1);
            recognitionengine.RecognizeAsync(RecognizeMode.Multiple);
        }
        private void call()
        {

            recognitionengine.SpeechRecognized += (s, args) =>
            {

                foreach (RecognizedWordUnit word1 in args.Result.Words)
                {
                    textBox3.Text = word1.Text;
                    if (word1.Text.Equals("login"))
                    {
                        //recognitionengine.RecognizeAsyncStop();
                        button1.PerformClick();
                        
                    }
                }

            };

            Grammar cg2= letterGrammar2();

            recognitionengine.LoadGrammar(cg2);
            recognitionengine.RecognizeAsync(RecognizeMode.Multiple);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            login log1 = new login();
            log1.recognitionengine.RecognizeAsyncStop();
            timer1.Interval = 1000;
            timer1.Start();
           select slt = new select();
            slt.Show();
           // this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
         
         
            label5.Text= hour.ToString() + ":" + min.ToString() + ":" + second.ToString();
            second = second + 1;
            if (second >= 60)
            {
                min = min + 1;
                second = 0;
            }
            if (min >= 60)
            {
                hour = hour + 1;
                min = 0;
            }
                if (second >= 10)//1800
            {
                timer1.Stop();
                result res = new result();
                res.Show();
                this.Hide();
                
              
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        }
    }

