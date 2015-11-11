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
            if (browser.Url.Equals("https://www.microsoftazurepass.com/"))
            {
                Console.WriteLine("Filling country code and promo code " + browser.Url);
                string[] attribute = new string[] { "ddlCountry", "tbPromo" };

                for (int index = 0; index < attribute.Length; index++)
                {
                    HtmlElement fillElement = browser.Document.GetElementById(attribute[index]);
                    fillElement.Focus();

                    switch (index)
                    {
                        case 0:
                            fillElement.SetAttribute("value", "830974e9-147b-e011-8167-001f29c6fb82");
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
            else if (browser.Url.Equals("https://www.microsoftazurepass.com/AAD?returnUrl=%2FRegistration&isAccountExisted=False"))
            {
                Console.WriteLine("Account is not exsist  " + browser.Url);
                browser.Document.GetElementById("loginLink").InvokeMember("click");

            }
            else if (browser.Url.Equals("https://www.microsoftazurepass.com/Registration/AzureAccountExist"))
            {
                Console.WriteLine("Account is exsit " + browser.Url );
            }

            else if (browser.Url.Equals("https://login.microsoftonline.com/72f988bf-86f1-41af-91ab-2d7cd011db47/oauth2/authorize?client_id=ca21d81b-8bfb-4c06-99d3-d493cb2d82c6&redirect_uri=https:%2f%2fwww.microsoftazurepass.com%2fRegistration&response_mode=form_post&response_type=code+id_token&scope=openid+profile&state=OpenIdConnect.AuthenticationProperties%3dKQj5ex_oq6feDBK_OjWr6auxfvvI7HMaeCADURzLN6h5mxRl1QCIDRBSxzSrN_i6aoLQKhjONslnvxkO0cAmXYAk4X4q0XZ_FuypZ-lhwyryt1LUF35JoKXZ4wKCijy1FIDYCmEWEG9zqqvUq95gwPUt7fEXIjo4oMhwDxK1TqnW716xm8rV-7Vh_rA-e2JHnuimkzQaeHgDxs29dT1A5mqlNqA&nonce=635827735502309268.NTE5MWU2NmUtYzk2Zi00YjE1LTg5NWUtYmQ2Yjc3MzUwOGU1MzA2ZjBjZWQtNDNiMi00NzQ1LTljMTctMzJmMjdhN2YwNjlm"))
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
            else
            {
                Console.WriteLine("Unknow Status " + browser.Url);
            }
          
        }
           
    }
}
