using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using StarTEDSystemDB.BLL;
using StarTEDSystemDB.Entities;


namespace StarTEDSystemWebApp.Components.Pages
{
    public partial class CRUD
    {

        [Inject]
        CourseServices CourseServices { get; set; }

        [Inject]
        ProgramServices ProgramServices { get; set; }

        [Inject]
        ProgramCourseServices ProgramCourseServices { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        //Required properties
        public List<StarTEDSystemDB.Entities.Program> Programs { get; set; }
        public List<ProgramCourse> Courses { get; set; }
        public List<ProgramCourse> ProgramCourses { get; set; }

        public List<string> errorList = new List<string>();
        public string feedback { get; set; }
        public Course Course { get; set; }

        [Parameter]
        public int ProgramId { get; set; }
      
        [Parameter]
        public string CourseId { get; set; }
        
        [Parameter]
        public bool Required { get; set; }

        [Parameter]
        public bool Active { get; set; }



        //ProgramCourse fields

        public string Comments { get; set; }
        public int SectionLimit { get; set; } 
        public ProgramCourse ProgramCourse { get; set; }


        protected override Task OnInitializedAsync()
        {
            var uri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);

            Programs = ProgramServices.GetAllPrograms();

            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("CourseId", out var courseId))
            {
                //Course = CourseServices.GetCourseById(courseId);
                ProgramCourse = ProgramCourseServices.GetProgramCourseById(courseId);
            }

            return Task.FromResult(true);
        }

        private void OnHandleAddProgramCourse()
        {
            ValidateFields();
        }

        private async Task HandleSelectedProgram(ChangeEventArgs e)
        {
            ProgramId = Convert.ToInt32(e.Value);
            if (ProgramId != 0)
            {
                ProgramCourses = ProgramCourseServices.GetAllProgramCourses(ProgramId);
                await InvokeAsync(StateHasChanged);
            }            
        }

        private async Task HandleSelectedCourse(ChangeEventArgs e)
        {
            CourseId = Convert.ToString(e.Value);
            if (CourseId != "")
            {
                //Course = CourseServices.GetCourseById(CourseId);
                ProgramCourse = ProgramCourseServices.GetProgramCourseById(CourseId);

                await InvokeAsync(StateHasChanged);
            }
        }

        //TODO: revise error handling may not need all fields
        private void ValidateFields()
        {
            if (ProgramId == 0)
            {
                feedback = "Please select a program from the list";
                errorList.Add($"Error {errorList.Count + 1}: " + feedback);

            }

            if (string.IsNullOrWhiteSpace(CourseId))
            {
                feedback = "Please select a course from the list";
                errorList.Add($"Error {errorList.Count + 1}: " + feedback);

            }
            if (Required == false)
            {
                feedback = "Please indicate if the course is required";
                errorList.Add($"Error {errorList.Count + 1}: " + feedback);
            }           

            if (Required == false)
            {
                feedback = "Please indicate if the course should be active";
                errorList.Add($"Error {errorList.Count + 1}: " + feedback);
            }
        }
        private void ClearFields()
        {
            //Select components
            ProgramId = 0;
            CourseId = "";

            //Course Fields
            //ProgramCourse.Course.Credits = 0;
            //ProgramCourse.Course.TotalHours = 0;
            //ProgramCourse.Course.ClassroomType = 0;
            //ProgramCourse.Course.Term = 0;
            //ProgramCourse.Course.Tuition = 0;
            //ProgramCourse.Required = false;
            //ProgramCourse.Active = false;

            ProgramCourse = null;
            ProgramCourses = null;


            //ProgramCourse Fields
            Required = false;
            Comments = "";
            SectionLimit = 0;
            Active = false;
        }

        private void DeleteCourse()
        {

        }

        private void EditCourse()
        {

        }

        private void AddCourse()
        {

        }

    }
}
