using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_IT.Models
{
    public class MyContext : IdentityDbContext
    {

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Tabela de legaturin dintre user si role. Many-To-Many
            #region
            modelBuilder.Entity<UserRole>()
                    .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne<User>(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);
            modelBuilder.Entity<UserRole>()
                .HasOne<Role>(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
            #endregion

            // Constraint pentru tabela de Article. Un user poate sa aiba mai multe articole - un articol apartine doar unui user.
            #region 
            modelBuilder.Entity<Article>().HasKey(a => a.Id);

            modelBuilder.Entity<Article>()
                .HasOne<User>(a => a.User)
                .WithMany(u => u.Articles).
                HasForeignKey(u => u.UserId);
               
            #endregion

            //Roles

            modelBuilder.Entity<Role>().HasKey(r => r.Id);


            //Constraint-uri pentru tabelele Course si User - Many-To-Many
            #region 

            modelBuilder.Entity<Course>().HasKey(c => c.Id);


           modelBuilder.Entity<UserCourse>()
                .HasKey(uc => new { uc.UserId, uc.CourseId });
            modelBuilder.Entity<UserCourse>()
                .HasOne<User>(uc => uc.User)
                .WithMany(u => u.UserCourses)
                .HasForeignKey(uc => uc.UserId);
            modelBuilder.Entity<UserCourse>()
                .HasOne<Course>(uc => uc.Course)
                .WithMany(c => c.UserCourses)
                .HasForeignKey(ur => ur.CourseId);

            #endregion

            #region
            //Constraint pentru tabela Chapter - un curs poate sa aiba mai multe capitole
            //One-To-Many

            modelBuilder.Entity<Chapter>().HasKey(c => c.Id);

            modelBuilder.Entity<Chapter>()
                    .HasOne(ch => ch.Course)
                    .WithMany(c => c.Chapters)
                    .HasForeignKey(ch => ch.CourseId);
            #endregion

            #region
            //Examen la capitol - One-To-One

            modelBuilder.Entity<Exam>().HasKey(e => e.Id);

            modelBuilder.Entity<Exam>()
                .HasOne<Course>(e => e.Course)
                .WithOne(c => c.Exam);
                //.HasForeignKey<Course>(c => c.Id);

            #endregion

            #region
            //Intrebari la examen -  Many-To-Many 

            modelBuilder.Entity<Question>().HasKey(q => q.Id);

                modelBuilder.Entity<QuestionExam>()
                    .HasKey(qe => new { qe.ExamId, qe.QuestionId });
            modelBuilder.Entity<QuestionExam>()
                .HasOne<Question>(qe => qe.Question)
                .WithMany(q => q.QuestionExams)
                .HasForeignKey(qe => qe.QuestionId);
            modelBuilder.Entity<QuestionExam>()
                .HasOne<Exam>(qe => qe.Exam)
                .WithMany(e => e.QuestionExams)
                .HasForeignKey(qe => qe.ExamId);
            #endregion

            #region
            //Raspunsuri la intrebari - Many-to-Many

            modelBuilder.Entity<Answer>().HasKey(a => a.Id);

            modelBuilder.Entity<AnswerQuestion>()
                .HasKey(aq => new { aq.AnswerId, aq.QuestionId });
            modelBuilder.Entity<AnswerQuestion>()
                .HasOne<Question>(aq => aq.Question)
                .WithMany(q => q.AnswerQuestions)
                .HasForeignKey(aq => aq.QuestionId);
            modelBuilder.Entity<AnswerQuestion>()
                .HasOne<Answer>(aq => aq.Answer)
                .WithMany(a => a.AnswerQuestions)
                .HasForeignKey(aq => aq.AnswerId);
            #endregion

            #region
            //Constraint pentru tabela Badge-User - un user poate sa aiba mai multe badgeuri
            //Many-To-Many

            modelBuilder.Entity<User>().HasKey(c => c.Id);


            modelBuilder.Entity<UserBadge>()
                 .HasKey(uc => new { uc.BadgeId, uc.UserID });
            modelBuilder.Entity<UserBadge>()
                .HasOne<User>(uc => uc.User)
                .WithMany(u => u.UserBadges)
                .HasForeignKey(uc => uc.UserID);
            modelBuilder.Entity<UserBadge>()
                .HasOne<Badge>(uc => uc.Badge)
                .WithMany(c => c.UserBadges)
                .HasForeignKey(ur => ur.BadgeId);
            #endregion

            #region
            //Badge la curs - One-To-One

            modelBuilder.Entity<Badge>().HasKey(e => e.Id);

            modelBuilder.Entity<Badge>()
                .HasOne<Course>(e => e.Course)
                .WithOne(ch => ch.Badge);
            //.HasForeignKey<Chapter>(c => c.CourseId);

            #endregion
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<QuestionExam> QuestionExams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerQuestion> AnswerQuestions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<UserBadge> UserBadges { get; set; }
    }
}
