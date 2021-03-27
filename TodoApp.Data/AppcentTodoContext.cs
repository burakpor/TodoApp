using Microsoft.EntityFrameworkCore;
using TodoApp.Entity;

namespace TodoApp
{
    public partial class AppcentTodoContext : DbContext
    {
        public AppcentTodoContext()
        {
        }

        public AppcentTodoContext(DbContextOptions<AppcentTodoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcCategory> AcCategory { get; set; }
        public virtual DbSet<AcTask> AcTask { get; set; }
        public virtual DbSet<AcTaskActivity> AcTaskActivitiy { get; set; }
        public virtual DbSet<AcTaskComment> AcTaskComment { get; set; }
        public virtual DbSet<AcTaskLabel> AcTaskLabel { get; set; }
        public virtual DbSet<AcTaskPriority> AcTaskPriority { get; set; }
        public virtual DbSet<AcTaskStatus> AcTaskStatus { get; set; }
        public virtual DbSet<AcUser> AcUser { get; set; }
        public virtual DbSet<TestTable> TestTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=35.234.83.227;Initial Catalog=AppcentTodo;User Id=sqlserver;Password=testdbpassword;Persist Security Info=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AcCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__AcCatego__3214EC07283F999B");

                entity.ToTable("AcCategory");

                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<AcTask>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("PK__AcTask__7C6949B1FFC1FAC7");

                entity.ToTable("AcTask");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.AcTasks)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__AcTask__Category__47DBAE45");

                entity.HasOne(d => d.RootTask)
                    .WithMany(p => p.InverseRootTask)
                    .HasForeignKey(d => d.RootTaskId)
                    .HasConstraintName("FK__AcTask__RootTask__49C3F6B7");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.AcTasks)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK__AcTask__Status__48CFD27E");

                entity.HasOne(d => d.TaskPriority)
                    .WithMany(p => p.AcTasks)
                    .HasForeignKey(d => d.TaskPriorityId)
                    .HasConstraintName("FK__AcTask__TaskPrio__4AB81AF0");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AcTasks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__AcTask__UserId__46E78A0C");
            });

            modelBuilder.Entity<AcTaskActivity>(entity =>
            {
                entity.HasKey(e => e.TaskActivityId)
                    .HasName("PK__AcTaskAc__46F9BE0F12C71ED5");

                entity.ToTable("AcTaskActivity");

                entity.Property(e => e.Activity)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ActivityDate).HasColumnType("datetime");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.AcTaskActivities)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK__AcTaskAct__TaskI__4D94879B");
            });

            modelBuilder.Entity<AcTaskComment>(entity =>
            {
                entity.HasKey(e => e.TaskCommentId)
                    .HasName("PK__AcTaskCo__CD2D202951D36F50");

                entity.ToTable("AcTaskComment");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.AcTaskComments)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK__AcTaskCom__TaskI__5070F446");
            });

            modelBuilder.Entity<AcTaskLabel>(entity =>
            {
                entity.HasKey(e => e.TaskLabelId)
                    .HasName("PK__AcTaskLa__1398190A8D9FD606");

                entity.ToTable("AcTaskLabel");

                entity.Property(e => e.Label).HasMaxLength(50);

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.AcTaskLabels)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK__AcTaskLab__TaskI__534D60F1");
            });

            modelBuilder.Entity<AcTaskPriority>(entity =>
            {
                entity.HasKey(e => e.TaskPriorityId)
                    .HasName("PK__AcTaskPr__BBFB9D8BF6168162");

                entity.ToTable("AcTaskPriority");

                entity.Property(e => e.Priority)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AcTaskStatus>(entity =>
            {
                entity.HasKey(e => e.TaskStatusId)
                    .HasName("PK__AcTodoSt__3214EC07097C3117");

                entity.ToTable("AcTaskStatus");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AcUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__3214EC07EC4857A5");

                entity.ToTable("AcUser");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TestTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TestTable");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Test).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
