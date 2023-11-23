#define FIRST
#if FIRST  // First DbInitializer used
#region snippet
using GeoProfs.Models;

namespace GeoProfs.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GeoProfsContext context)
        {
            //Look for any users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User{FirstName="Carson",LastName="Alexander",DateService=DateTime.Parse("2019-09-01")},
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var accounts = new Account[]
            {
                //new Account{Name="Iris", Password="Reijnen", Email="i.g.r@gmail.com"},
            };

            context.Accounts.AddRange(accounts);
            context.SaveChanges();

            var leaveRequests = new LeaveRequest[]
            {
                //new LeaveRequest{Description="Test"},
            };

            context.LeaveRequests.AddRange(leaveRequests);
            context.SaveChanges();

            var statuses = new Status[]
            {
                //new Status{Name="In Behandeling"},
                //new Status{Name="Afgekeurd"},
                //new Status{Name="Goed gekeurd"},
            };

            context.Statuses.AddRange(statuses);
            context.SaveChanges();

            var reasons = new Reason[]
            {
                new Reason{Name="Sick"},
                new Reason{Name="Vacation"},
                new Reason{Name="Personal"},
            };

            context.Reasons.AddRange(reasons);
            context.SaveChanges();

            //var enrollments = new Enrollment[]
            //{
            //    new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            //    new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            //    new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            //    new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            //    new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            //    new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            //    new Enrollment{StudentID=3,CourseID=1050},
            //    new Enrollment{StudentID=4,CourseID=1050},
            //    new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            //    new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            //    new Enrollment{StudentID=6,CourseID=1045},
            //    new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            //};

            //context.Enrollments.AddRange(enrollments);
            //context.SaveChanges();
        }
    }
}
#endregion
#endif