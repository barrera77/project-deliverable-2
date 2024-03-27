using Microsoft.AspNetCore.Components;
using StarTEDSystemDB.BLL;
using StarTEDSystemDB.Entities;
using System.Data.SqlTypes;

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
        public List<ProgramCourse> ProgramCourses { get; set; }

        public List<string> errorList = new List<string>();
        public string feedback { get; set; }


        [Parameter]
        public int ProgramId { get; set; }

        //Course fields
        [Parameter]
        public string CourseId { get; set; }

        [Parameter]
        public string CourseName { get; set; }

        [Parameter]
        public double Credits { get; set; }

        [Parameter]
        public int TotalHours { get; set; }

        [Parameter]
        public int ClassroomType { get; set; }

        [Parameter]
        public int Term { get; set;}

        [Parameter]
        public double Tuition { get; set; }

        [Parameter]
        public string Description { get; set; }

        //ProgramCourse fields
        [Parameter]
        public bool Required { get; set; }
        [Parameter]
        public string Comments { get; set; }

        [Parameter]
        public int SectionLimit { get; set; }       

        [Parameter]
        public bool Active { get; set; }

       

        protected override Task OnInitializedAsync()
        {
            return Task.Run(() =>
            {
                Programs = ProgramServices.GetAllPrograms();

            });
        }

        private void OnHandleAddCourse()
        {
            ValidateFields();

        }

        private void ValidateFields()
        {
            if (ProgramId == 0)
            {
                feedback = "Please select a program";
                errorList.Add($"Error {errorList.Count + 1}: " + feedback);
            }

            if (string.IsNullOrWhiteSpace(CourseName))
            {
                feedback = "Please provide a course name";
                errorList.Add($"Error {errorList.Count + 1}: " + feedback);
            }

            if (Credits == 0)
            {
                feedback = "Please provide the credits for the course";
                errorList.Add($"Error {errorList.Count + 1}: " + feedback);
            }

            if (TotalHours == 0)
            {
                feedback = "Please provide the total hours of the course";
                errorList.Add($"Error {errorList.Count + 1}: " + feedback);
            }

            if (Term == 0)
            {
                feedback = "Please provide the term for the course";
                errorList.Add($"Error {errorList.Count + 1}: " + feedback);
            }

            if (Tuition == 0)
            {
                feedback = "Please provide the tuition costs for the course";
                errorList.Add($"Error {errorList.Count + 1}: " + feedback);
            }

            if (string.IsNullOrWhiteSpace(Description))
            {
                feedback = "Please provide a description for the course";
                errorList.Add($"Error {errorList.Count + 1}: " + feedback);
            }

            if (Required == false)
            {
                feedback = "Please indicate if the course is required or not";
                errorList.Add($"Error {errorList.Count + 1}: " + feedback);
            }

            //if (string.IsNullOrWhiteSpace(Comments))
            //{
            //    feedback = "error";
            //    errorList.Add($"Error: {errorList.Count + 1}" + feedback);
            //}

            if (Required == false)
            {
                feedback = "Please indicate if the course is active or not";
                errorList.Add($"Error {errorList.Count + 1}: " + feedback);
            }

        }
        private void ClearFields()
        {
            //Select component
            ProgramCourses = null;

            //Course Fields
            CourseName = "";
            Credits = 0;
            TotalHours = 0;
            ClassroomType = 0;
            Term = 0;
            Tuition = 0;
            Description = "";

            //ProgramCourse Fields
            Required = false;
            Comments = "";
            SectionLimit = 0;
            Active = false;
        }
    }
}
