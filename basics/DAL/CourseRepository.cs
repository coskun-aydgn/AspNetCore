using basics.Models;

namespace basics.DAL
{
    public class CourseRepository
    {
        private static readonly List<Course> _courses = new List<Course> { };
        static CourseRepository()
        {
            _courses = new List<Course>()

            {
                new Course
                {
                    Id = 1,
                    Title = "React",
                    Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.",
                    ImageUrl = "react.webp",
                    Tags = new string[] { "Frontend", "JavaScript", "Web Development" },
                    isActive = true,
                    isHome = true
                },
                new Course
                {
                    Id = 2,
                    Title = "Angular",
                    Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.",
                    ImageUrl = "C++.webp",
                    Tags = new string[] { "Frontend", "TypeScript", "Web Development" },
                    isActive = true,
                    isHome = false
                },
                new Course
                {
                    Id = 3,
                    Title = "Vue.js",
                    Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.",
                    ImageUrl = "js.webp",
                    Tags = new string[] { "Frontend", "JavaScript", "Web Development" },
                    isActive = false,
                    isHome = true
                },
                new Course
                {
                    Id = 4,
                    Title = "JavaScript",
                    Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.",
                    ImageUrl = "javascript.webp",
                    Tags = new string[] { "Programming", "Web Development", "Dynamic" },
                    isActive = true,
                    isHome = false
                },
                new Course
                {
                    Id = 5,
                    Title = "TypeScript",
                    Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.",
                    ImageUrl = "python.webp",
                    Tags = new string[] { "Programming", "Type-Safe", "Frontend" },
                    isActive = true,
                    isHome = true
                },
                new Course
                {
                    Id = 6,
                    Title = "C#",
                    Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.",
                    ImageUrl = "react.webp",
                    Tags = new string[] { "Backend", "Object-Oriented", ".NET" },
                    isActive = false,
                    isHome = false
                },
                new Course
                {
                    Id = 7,
                    Title = "Python",
                    Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.",
                    ImageUrl = "ts.webp",
                    Tags = new string[] { "Programming", "Machine Learning", "Web Development" },
                    isActive = true,
                    isHome = true
                },
                new Course
                {
                    Id = 8,
                    Title = "Java",
                    Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.",
                    ImageUrl = "react.webp",
                    Tags = new string[] { "Backend", "Object-Oriented", "Enterprise" },
                    isActive = false,
                    isHome = true
                },
                new Course
                {
                    Id = 9,
                    Title = "SQL",
                    Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.",
                    ImageUrl = "js.webp",
                    Tags = new string[] { "Database", "Query Language", "Data Management" },
                    isActive = true,
                    isHome = true
                },
                new Course
                {
                    Id = 10,
                    Title = "HTML & CSS",
                    Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.",
                    ImageUrl = "react.webp",
                    Tags = new string[] { "Web Design", "Frontend", "Markup" },
                    isActive = false,
                    isHome = false
                }
            };


        }
        public static List<Course> Courses
        {
            get
            {
                return _courses;
            }
        }
        public static Course? GetById(int? id)
        {
            return _courses.FirstOrDefault(c => c.Id == id);
        }
    }
}




