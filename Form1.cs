using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public partial class pass : Form
    {
        public pass()
        {
            InitializeComponent();
            
            browser.Navigate("https://www.microsoftazurepass.com/");

        }

        private void pass_Load(object sender, EventArgs e)
        {

        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string currentUrl = browser.Url.ToString();
            string[] url = currentUrl.Split('/');


            for(int index = 0; index < url.Length; index++)
                Console.WriteLine("url["+index+"] "+ url[index]);

            // Azure Pass Promo Page
            if (browser.Url.Equals("https://www.microsoftazurepass.com/"))
           

            //if (url[2].Equals("www.microsoftazurepass.com"))
            {
                Console.WriteLine("Filling country code and promo code " + browser.Url);
                string[] attribute = new string[] { "ddlCountry", "tbPromo" };

               //  fillElement; 
                for (int index = 0; index < attribute.Length; index++)
                {
                    HtmlElement fillElement = browser.Document.GetElementById(attribute[index]);

                        fillElement.Focus();

                        switch (index)
                        {
                            case 0:
                                //set Country value asa Taiwan  
                                fillElement.SetAttribute("value", "830974e9-147b-e011-8167-001f29c6fb82");
                                break;
                            case 1:
                                //filling promo code here 
                                fillElement.InnerText = "MCRV7QGJ9EMYXH";
                                break;
                        }

                        fillElement.RemoveFocus();
                    }
                

                // click submit 

                HtmlElementCollection input = this.browser.Document.GetElementsByTagName("input");
                for (int ii = 0; ii < input.Count; ii++)
                {
                    if (input[ii].GetAttribute("type").ToLower().Equals("submit"))
                    {
                        input[ii].InvokeMember("click");
                    }
                }
            }
            else if (browser.Url.Equals("https://www.microsoftazurepass.com/AAD?returnUrl=%2FRegistration&isAccountExisted=False"))
            {
                Console.WriteLine("Account is not exsist  " + browser.Url);
                browser.Document.GetElementById("loginLink").InvokeMember("click");

            }
            else if (browser.Url.Equals("https://www.microsoftazurepass.com/Registration/AzureAccountExist"))
            {
                Console.WriteLine("Account is exsit " + browser.Url );
            }




            else if (url[2].Equals("login.microsoftonline.com"))
            {
                Console.WriteLine("Login Plz  " + browser.Url);

                string[] attribute = new string[] { "cred_userid_inputtext","cred_password_inputtext"};

                // fill the element to login 
                for (int index = 0; index < attribute.Length; index++)
                {
                    HtmlElement fillElement = browser.Document.GetElementById(attribute[index]);
                    fillElement.Focus();

                    switch (index)
                    {
                        case 0:
                            fillElement.InnerText = "MS2015111001@outlook.com";
                            break;
                        case 1:
                            fillElement.InnerText = "MCRV7QGJ9EMYXH";
                            break;
                    }

                    fillElement.RemoveFocus();

                }
                
                // click submit 
                HtmlElementCollection input = this.browser.Document.GetElementsByTagName("input");
                for (int ii = 0; ii < input.Count; ii++)
                {
                    if (input[ii].GetAttribute("type").ToLower().Equals("submit"))
                    {
                        input[ii].InvokeMember("click");
                    }
                }
            }



            // auth login 
            else if (url[2].Equals("login.live.com"))
            {
                Console.WriteLine("Lfillig password   " + browser.Url);


                // fill the element to login 

                HtmlElement fillElement = browser.Document.GetElementById("i0118");
                fillElement.Focus();
                fillElement.InnerText = "MS20151110";

                fillElement.RemoveFocus();

                // click submit 
                HtmlElementCollection input = this.browser.Document.GetElementsByTagName("input");
                for (int ii = 0; ii < input.Count; ii++)
                {
                    if (input[ii].GetAttribute("type").ToLower().Equals("submit"))
                    {
                        input[ii].InvokeMember("click");
                    }
                }
            }





            else
            {
                Console.WriteLine("Unknow Status " + browser.Url);
            }
          
        }
           
    }
}
