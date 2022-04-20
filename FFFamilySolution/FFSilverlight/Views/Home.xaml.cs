using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.Serialization.Json;
using FFF.Silverlight.Library.Extensions;
using FFSilverlight.ViewModels;
using Microsoft.Http;
using System.Runtime.Serialization;
using System.IO;

namespace FFSilverlight
{
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();

            Show2();

            //WebClient client = new WebClient();

            //string baseUrl = "http://localhost:1107/service/authentication/";

            //client.OpenReadCompleted += (s, e) => {

            //    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(string));

            //    ContentText.Text = ser.ReadObject(e.Result).ToString();

            //};

            //client.OpenReadAsync(new Uri(baseUrl));

            //HttpClient client = new HttpClient();
            //string baseUrl = "http://localhost:1107/service/authentication/Hello?logid=Mary";
            
            //HttpResponseMessage msg = client.Post(baseUrl, HttpContentExtensions.CreateDataContract<string>(" And John"));

            //string aa = msg.Content.ReadAsJsonDataContract<string>();

            //LayoutRoot.DataContext = new MVVModel1() { CurrentPerson = new Person() { PersonID = "A1", PersonName = "MyName" }};



            //ContentStackPanel.DataContext = new MVVModel1() { A = new ViewModels.Person() { Message = "BBB", Message2="CCC" } };


            //new MVVModel1().Show((s, e) => { 
                
            //    //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(string));

            //    //ContentText.Text= ser.ReadObject(e.Result).ToString();

            //    //ContentText.Text = e.Result.ReadAsJsonDataContract<string>();

            //    //HeaderText.DataContext = e.Result.ReadAsJsonDataContract<string>();

            //});
            
            
        }

        public void Show2()
        {
            //WebClient client = new WebClient();
           
                

                string baseUrl = "http://localhost:1107/service/authentication/Hello?logid=Jack";
                //string baseUrl = "http://localhost:1107/service/authentication";

                HttpClient client = new HttpClient(baseUrl);

                
                client.PostAsync(baseUrl,HttpContentExtensions.CreateJsonDataContract<string>("Mary"),response => {

                    ContentText.Dispatcher.BeginInvoke(() => { 
                        
                        ContentText.Text= response.Content.ReadAsJsonDataContract<string>();   
                    
                    });
                 });

                

                //HttpResponseMessage msg = client.Get(baseUrl);

                //string aa = msg.Content.ReadAsJsonDataContract<string>();
           
           

            //client.UploadStringCompleted += (s, e) => {

            //    ContentText.Text = e.Result.JsonStringToObject<string>();
            //};

            //string data=("Mary").ObjectToJsonString<string>();

            //client.UploadStringAsync(new Uri(baseUrl),"PUT",data);
            //string baseUrl = "http://localhost:1107/service/authentication";

            //client.DownloadStringCompleted += (s, e) => {
            //    ContentText.Text = e.Result.JsonStringToObject<string>();
            //};

            //client.DownloadStringAsync(new Uri(baseUrl));

            //string baseUrl = "http://localhost:1107/service/authentication/Hello?logid=Jack";
            //DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(string)); 
            //MemoryStream memoryStream = new MemoryStream(); 
            //dataContractSerializer.WriteObject(memoryStream,"John"); 
            //string xmlData = Encoding.UTF8.GetString(memoryStream.ToArray(), 0, (int)memoryStream.Length); 
            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(string));
            //client.UploadStringCompleted += (s, ev) => 
            //{
            //    //ContentText.Text = ev.Result;
            //}; 
            //string data="John";
            //client.Headers[HttpRequestHeader.ContentType] = "application/json"; 
            //client.UploadStringAsync(new Uri(baseUrl), "POST",data.CreateJsonDataContract<string>(),);

            
            
            //string baseUrl = "http://localhost:1107/service/authentication";
            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(string));

            //client.OpenWriteCompleted+= (s, e) =>
            //{

            //    ContentText.Text = e.Result.ReadAsJsonDataContract<string>(); //ser.ReadObject(e.Result).ToString();

            //};

            //client.OpenWriteAsync(new Uri(baseUrl),"POST","john");
            
            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(string));

            //client.OpenWriteCompleted += (s, e) => {
 
            //    ContentText.Text = ser.ReadObject(e.Result).ToString();
            //};

            //MemoryStream stream = new MemoryStream();
            
            //ser.WriteObject(stream,"Mary");
            
            //client.OpenWriteAsync(new Uri(baseUrl), "POST",stream);
           
        }

        public void Show()
        {
            WebClient client = new WebClient();
            string baseUrl = "http://localhost:1107/service/authentication";

            client.OpenReadCompleted += (s, e) =>
            {

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(string));

                 ContentText.Text= ser.ReadObject(e.Result).ToString();

            };

            client.OpenReadAsync(new Uri(baseUrl));
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void sampleCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void sampleCalendar_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {

        }
    }
}