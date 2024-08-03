using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;

namespace WebAPI_Student_UI
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                fetch();
            }
        }

        public class StudentMarks
        {
            public int id { get; set; }

            [StringLength(50)]
            public string student_name { get; set; }

            public int tamil { get; set; }

            public int english { get; set; }

            public int maths { get; set; }

            public int science { get; set; }

            public int social_science { get; set; }

            public int total { get; set; }

            public decimal percentage { get; set; }
        }
        protected void btn_Insert_Click(object sender, EventArgs e)
        {
            if(txt_Name.Text != "" && txt_Tamil.Text != "" && txt_English.Text != "" && txt_Maths.Text!= "" && txt_Science.Text != "" && txt_SS.Text != "")
            {
                string apiUrl = "https://localhost:44350/api/tbl_student_marks";

                int tamil = Convert.ToInt32(txt_Tamil.Text.Trim());
                int english = Convert.ToInt32(txt_English.Text.Trim());
                int maths = Convert.ToInt32(txt_Maths.Text.Trim());
                int science = Convert.ToInt32(txt_Science.Text.Trim());
                int social_science = Convert.ToInt32(txt_SS.Text.Trim());


                int total = tamil + english + maths + science + social_science;
                decimal percentage = total / 5m;

                var stu_Marks = new
                {
                    student_name = txt_Name.Text.Trim(),
                    tamil = tamil,
                    english = english,
                    maths = maths,
                    science = science,
                    social_science = social_science,
                    total = total,
                    percentage = percentage
                };

                string inputJson = (new JavaScriptSerializer().Serialize(stu_Marks));
                HttpClient client = new HttpClient();
                HttpContent content = new StringContent(inputJson, Encoding.UTF8, "application/json");
                HttpResponseMessage responce = (client.PostAsync(apiUrl + "/tbl_student_marks", content).Result);
                if (responce.IsSuccessStatusCode)
                {
                    lblError.Text = "";
                    lblSuccess.Text = "Data Inserted Successfully";
                    Clear();
                    fetch();
                }
                else
                {
                    lblError.Text = "Data Not Added";
                    lblSuccess.Text = "";
                }
            }
            else
            {
                lblError.Text = "Must fill all the field";
                lblSuccess.Text = "";
            }
           
        }

        public void fetch()
        {
            string apiUrl = "https://localhost:44350/api/tbl_student_marks";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage responce = client.GetAsync(apiUrl).Result;
            if(responce.IsSuccessStatusCode)
            {
                var dataObjects = responce.Content.ReadAsAsync<IEnumerable<StudentMarks>>().Result;
                GridView1.DataSource = dataObjects;
                GridView1.DataBind();
            }

        }
        private bool UpdateMarks(StudentMarks mark)
        {
            if (txt_Name.Text != "" && txt_Tamil.Text != "" && txt_English.Text != "" && txt_Maths.Text != "" && txt_Science.Text != "" && txt_SS.Text != "")
            {
                string apiUrl = $"https://localhost:44350/api/tbl_student_marks/{mark.id}";

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync(apiUrl, mark).Result;
                return response.IsSuccessStatusCode;
            }
            else 
            {
                return false;
            }
         
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(int.TryParse(txt_search.Text.Trim(),out int id))
            {
                
                int tamil = Convert.ToInt32(txt_Tamil.Text.Trim());
                int english = Convert.ToInt32(txt_English.Text.Trim());
                int maths = Convert.ToInt32(txt_Maths.Text.Trim());
                int science = Convert.ToInt32(txt_Science.Text.Trim());
                int social_science = Convert.ToInt32(txt_SS.Text.Trim());


                int total = tamil + english + maths + science + social_science;
                decimal percentage = total / 5m;

                StudentMarks mark = new StudentMarks
                {
                    id = id,
                    student_name = txt_Name.Text.Trim(),
                    tamil = tamil,
                    english = english,
                    maths = maths,
                    science = science,
                    social_science = social_science,
                    total = total,
                    percentage = percentage

                };
                bool isValid = UpdateMarks(mark);
                if(isValid)
                {
                    lblError.Text = "";
                    lblSuccess.Text = "Updated Successfully";
                    fetch();
                    Clear();
                    
                }
                else
                {
                    lblError.Text = "Error Updated";
                    lblSuccess.Text = "";
                }
            }
            else
            {
                lblError.Text = "Error Updated";
                lblSuccess.Text = "";
            }
        }

        private StudentMarks GetMarksById(int id)
        {
            string apiUrl = $"https://localhost:44350/api/tbl_student_marks/{id}";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                var mark = response.Content.ReadAsAsync<StudentMarks>().Result;
                return mark;
            }
            else
            {
                return null;
            }
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
           if(int.TryParse(txt_search.Text.Trim(), out int id))
            {
                StudentMarks mark = GetMarksById(id);
                if(mark != null)
                {
                    txt_Name.Text = mark.student_name.ToString();
                    txt_Tamil.Text = mark.tamil.ToString();
                    txt_English.Text = mark.english.ToString();
                    txt_Maths.Text = mark.maths.ToString();
                    txt_Science.Text = mark.science.ToString();
                    txt_SS.Text = mark.social_science.ToString();
                }
                else
                {
                    lblError.Text = "Check Your id";
                    lblSuccess.Text = "";
                }
            }

        }
        private bool DeleteMarksById(int id )
        {
            string apiUrl = $"https://localhost:44350/api/tbl_student_marks/{id}";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri( apiUrl );
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.DeleteAsync(apiUrl).Result;

            return response.IsSuccessStatusCode;
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            if(int.TryParse(txt_search.Text.Trim(), out int id))
            {
                bool isDelete = DeleteMarksById(id);
                if(isDelete)
                {
                    lblSuccess.Text = "Student data deleted Successfully";
                    lblError.Text = "";
                    Clear();
                }
                else
                {
                    lblSuccess.Text = " ";
                    lblError.Text = "Check Your id";
                }
            }
            else
            {
                lblSuccess.Text = "";
                lblError.Text = "Error data deleted";
            }
        }
        public void Clear()
        {
            txt_Name.Text= txt_Tamil.Text = txt_English.Text = txt_Maths.Text  = string.Empty;
            txt_Science.Text = txt_search.Text = txt_SS.Text = string.Empty;
        }
    }
}