using MayEpCHADesktopApp.Core.Components;
using MayEpCHADesktopApp.Core.Model;
using MayEpCHADesktopApp.Core.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MayEpCHADesktopApp.Core.Services
{
    public class ApiServices : IApiServices
    {
        public event Action ChangeEvent;
        public event Action ChangeConfigEvent;
        private readonly IDatabaseServices _databaseServices;
        private HttpClient httpClient;
        private HttpRequestMessage httpRequest;
        // private string Address = "https://localhost:7202/";
        private string Address = "http://10.84.50.10:8081/";
        //private string Address = "https://chainjectionmoldingmachine.azurewebsites.net/";
        public ObservableCollection<Employee> ListEmployee = new ObservableCollection<Employee>();
        public ObservableCollection<Mold> ListMold = new ObservableCollection<Mold>();
        public ObservableCollection<Product> ListProduct = new ObservableCollection<Product>();
        public ObservableCollection<Machine> ListMachine = new ObservableCollection<Machine>();
        public ObservableCollection<ShiftReport> ListShiftReport = new ObservableCollection<ShiftReport>();
        public ObservableCollection<ShiftReport> ListPreShiftReports = new ObservableCollection<ShiftReport>( );
        public ObservableCollection<PreShiftReport> ListPreShiftReport = new ObservableCollection<PreShiftReport>( );
        public ShiftReports ShiftReports = new ShiftReports();
        public ApiServices(IDatabaseServices databaseServices)
        {
            _databaseServices=databaseServices;
        }
        public void StoreEvent (string NameEvent,string MachineId)
        {
            MayEpCHADesktopApp.Core.Database.ModelDatabase.EventMachine eventMachine1 = new Database.ModelDatabase.EventMachine( );
            eventMachine1.NameEvent=NameEvent;
            eventMachine1.Status=0;
            eventMachine1.DateTime=DateTime.UtcNow;
            eventMachine1.Status=0;
            eventMachine1.MachineId=MachineId;
            _databaseServices.InsertEventAsync(eventMachine1);
        }

        public async Task<ObservableCollection<Machine>> GetMachineTotal(string auth)
        {
            try
            {
                using (httpClient = new HttpClient())
                {
                    using (httpRequest = new HttpRequestMessage())
                    {
                        httpRequest.Headers.Add("User-Agent", "Mozilla/5.0");
                        string Url = Address + "api/machines";
                        httpRequest.Method = System.Net.Http.HttpMethod.Get;
                        httpRequest.RequestUri = new Uri(Url);
                        HttpResponseMessage httpResponse = await httpClient.SendAsync(httpRequest);
                        var ob = await httpResponse.Content.ReadAsStringAsync();
                        ListMachine = JsonConvert.DeserializeObject<ObservableCollection<Machine>>(ob);
                    }
                }

            }
            catch
            {
              //  CustomMessageBox.Show("Lỗi trong quá trình lấy dữ liệu từ Sever!", "Cảnh bảo", System.Windows.MessageBoxButton.OKCancel, System.Windows.MessageBoxImage.Warning);
                StoreEvent("Lỗi lấy dữ liệu tên máy ép","All Machine");
                ChangeEvent?.Invoke( );
            }

            return ListMachine;
        }
        public async Task<ObservableCollection<Employee>> GetEmployeeTotal(string auth)
        {
            try
            {
                using (httpClient = new HttpClient())
                {
                    using (httpRequest = new HttpRequestMessage())
                    {
                        httpRequest.Headers.Add("User-Agent", "Mozilla/5.0");
                        string Url = Address + "api/employees";
                        httpRequest.Method = System.Net.Http.HttpMethod.Get;
                        httpRequest.RequestUri = new Uri(Url);
                        HttpResponseMessage httpResponse = await httpClient.SendAsync(httpRequest);
                        var ob = await httpResponse.Content.ReadAsStringAsync();
                        ListEmployee = JsonConvert.DeserializeObject<ObservableCollection<Employee>>(ob);
                    }

                }

            }
            catch
            {
                StoreEvent("Lỗi lấy dữ liệu tên nhân viên","All Machine");
                ChangeEvent?.Invoke( );
                //  CustomMessageBox.Show("Lỗi trong quá trình lấy dữ liệu từ Sever!", "Cảnh bảo", System.Windows.MessageBoxButton.OKCancel, System.Windows.MessageBoxImage.Warning);
            }

            return ListEmployee;
        }

        public async Task<ObservableCollection<Mold>> GetMoldTotal(string auth)
        {
            try
            {
                using (httpClient = new HttpClient())
                {
                    using (httpRequest = new HttpRequestMessage())
                    {
                        string Url = Address + "api/molds";
                        httpRequest.Method = System.Net.Http.HttpMethod.Get;
                        httpRequest.RequestUri = new Uri(Url);
                        HttpResponseMessage httpResponse = await httpClient.SendAsync(httpRequest);
                        var ob = await httpResponse.Content.ReadAsStringAsync();
                        ListMold = JsonConvert.DeserializeObject<ObservableCollection<Mold>>(ob);

                    }

                }
            }
            catch
            {
                StoreEvent("Lỗi lấy dữ liệu tên khuôn","All Machine");
                ChangeEvent?.Invoke( );
                //    CustomMessageBox.Show("Lỗi trong quá trình lấy dữ liệu từ Sever!", "Cảnh bảo", System.Windows.MessageBoxButton.OKCancel, System.Windows.MessageBoxImage.Warning);
            }

            return ListMold;
        }

        public async Task<ObservableCollection<Product>> GetProductTotal(string auth)
        {
            try
            {
                using (httpClient = new HttpClient())
                {
                    using (httpRequest = new HttpRequestMessage())
                    {
                        string Url = Address + "api/products/details";
                        httpRequest.Method = System.Net.Http.HttpMethod.Get;
                        httpRequest.RequestUri = new Uri(Url);
                        HttpResponseMessage httpResponse = await httpClient.SendAsync(httpRequest);
                        var ob = await httpResponse.Content.ReadAsStringAsync();
                        ListProduct = JsonConvert.DeserializeObject<ObservableCollection<Product>>(ob);

                    }

                }

            }
            catch
            {
                StoreEvent("Lỗi lấy dữ liệu tên sản phẩm","All Machine");
                ChangeEvent?.Invoke( );
                //  CustomMessageBox.Show("Lỗi trong quá trình lấy dữ liệu từ Sever!", "Cảnh bảo", System.Windows.MessageBoxButton.OKCancel, System.Windows.MessageBoxImage.Warning);
            }

            return ListProduct;

        }
        public async Task<ObservableCollection<ShiftReport>> GetShiftReportTotal(string auth)
        {
            try
            {
                using (httpClient = new HttpClient())
                {
                    using (httpRequest = new HttpRequestMessage())
                    {
                        string Url = Address + "api/shiftreports";
                        httpRequest.Method = System.Net.Http.HttpMethod.Get;
                        httpRequest.RequestUri = new Uri(Url);
                        HttpResponseMessage httpResponse = await httpClient.SendAsync(httpRequest);
                        var ob = await httpResponse.Content.ReadAsStringAsync();
                        ShiftReports = JsonConvert.DeserializeObject<ShiftReports>(ob);
                        foreach (ShiftReport item in ShiftReports.items)
                        {
                            ListShiftReport.Add(item);
                        }
                    }

                }
            }
            catch
            {
                StoreEvent("Lỗi lấy dữ liệu thông tin nhân viên","All Machine");
                ChangeEvent?.Invoke( );
                // CustomMessageBox.Show("Lỗi trong quá trình lấy dữ liệu từ Sever!", "Cảnh bảo", System.Windows.MessageBoxButton.OKCancel, System.Windows.MessageBoxImage.Warning);
            }

            return ListShiftReport;

        }
        public async Task PutShiftReport(string auth, ShiftReport ShiftReport)
        {

            try
            {
                string data = JsonConvert.SerializeObject(ShiftReport);
                var content = new StringContent("["+data+"]", Encoding.UTF8, "application/json");
                using (httpClient = new HttpClient())
                {
                    using (httpRequest = new HttpRequestMessage())
                    {
                        string Url = Address + "api/shiftreports";
                        httpRequest.Method = System.Net.Http.HttpMethod.Put;
                        httpRequest.RequestUri = new Uri(Url);
                        httpRequest.Content = content;
                        HttpResponseMessage httpResponse = await httpClient.SendAsync(httpRequest);
                        if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                           // CustomMessageBox.Show("Gửi dữ liệu thành công", "Thông báo", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Asterisk);
                        }
                        else
                        {
                            //CustomMessageBox.Show("Gửi dữ liệu không thành công.", "Lỗi", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Error);
                        }
                    }

                }
            }
            catch
            {
                //   CustomMessageBox.Show("Lỗi trong quá trình gửi dữ liệu lên server!", "Cảnh bảo", System.Windows.MessageBoxButton.OKCancel, System.Windows.MessageBoxImage.Warning);
            }

        }
        public async Task PostShiftReportSingle (string auth,PreShiftConfiguration preShiftConfiguration)
        {
            try
            {
                string data = JsonConvert.SerializeObject(preShiftConfiguration);
                var content = new StringContent("["+data+"]",Encoding.UTF8,"application/json");
                using ( httpClient=new HttpClient( ) )
                {
                    using ( httpRequest=new HttpRequestMessage( ) )
                    {
                        string Url = Address+"api/shiftreports";
                        httpRequest.Method=System.Net.Http.HttpMethod.Post;
                        httpRequest.RequestUri=new Uri(Url);
                        httpRequest.Content=content;
                        HttpResponseMessage httpResponse = await httpClient.SendAsync(httpRequest);
                        if ( httpResponse.StatusCode==System.Net.HttpStatusCode.OK )
                        {
                            ChangeConfigEvent?.Invoke( );

                            // CustomMessageBox.Show("Gửi dữ liệu thành công", "Thông báo", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Asterisk);
                        }
                        else
                        {

                            // CustomMessageBox.Show("Gửi dữ liệu không thành công.", "Lỗi", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Error);
                        }

                    }

                }

            }
            catch
            {
                //   CustomMessageBox.Show("Lỗi trong quá trình gửi dữ liệu lên server!", "Cảnh bảo", System.Windows.MessageBoxButton.OKCancel, System.Windows.MessageBoxImage.Warning);
            }

        }
        public async Task<ObservableCollection<ShiftReport>> GetPreShiftReportTotal (string auth)
        {
            if ( ListPreShiftReports!=null )
            {
                ListPreShiftReports.Clear( );
            }
            try
            {

                using ( httpClient=new HttpClient( ) )
                {
                    using ( httpRequest=new HttpRequestMessage( ) )
                    {
                        string Url = Address+"api/shiftreports/preshifts";
                        httpRequest.Method=System.Net.Http.HttpMethod.Get;
                        httpRequest.RequestUri=new Uri(Url);
                        HttpResponseMessage httpResponse = await httpClient.SendAsync(httpRequest);
                        var ob = await httpResponse.Content.ReadAsStringAsync( );

                        ListPreShiftReport=JsonConvert.DeserializeObject<ObservableCollection<PreShiftReport>>(ob);
                        foreach ( PreShiftReport item in ListPreShiftReport )
                        {
                            var shiftReport = new ShiftReport( );
                            shiftReport.Date=item.date;
                            shiftReport.ShiftNumber=item.shiftNumber;
                            shiftReport.EmployeeId="";
                            shiftReport.ProductId=item.product.ProductId;
                            shiftReport.TotalQuantity=item.totalQuantity;
                            shiftReport.InjectionCycle=item.injectionCycle;
                            shiftReport.StartTime=item.date;
                            shiftReport.StopTime=item.date;
                            shiftReport.WorkTime=0;
                            shiftReport.PauseTime=0;
                            shiftReport.Note="";
                            shiftReport.Shots=null;
                            shiftReport.MachineId=item.machine.Id;
                            shiftReport.Cavity=item.product.Mold.ProductsPerShot;
                            ListPreShiftReports.Add(shiftReport);
                        }
                    }
                }
            }
            catch
            {
                StoreEvent("Lỗi lấy dữ liệu thông tin nhân viên","All Machine");
                ChangeEvent?.Invoke( );
                // CustomMessageBox.Show("Lỗi trong quá trình lấy dữ liệu từ Sever!", "Cảnh bảo", System.Windows.MessageBoxButton.OKCancel, System.Windows.MessageBoxImage.Warning);
            }
            return ListPreShiftReports;

        }
    }
}
