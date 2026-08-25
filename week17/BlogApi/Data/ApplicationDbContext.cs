using Microsoft.EntityFrameworkCore;
using BlogApi.Models;

namespace BlogApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Author> Author { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comment { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>() //Realationship between the post to atuhor
            .HasOne(e => e.Author)
            .WithMany(e => e.Posts)
            .HasForeignKey(e => e.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Post>()
            .HasMany(e => e.Comments)
            .WithOne(e => e.Post)
            .HasForeignKey(e => e.PostId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, FullName = "Sarah Johnson", Email = "sarah.j@example.com", JoinedDate = new DateTime(2023, 1, 15) },
            new Author { Id = 2, FullName = "Michael Chen", Email = "m.chen@example.com", JoinedDate = new DateTime(2023, 3, 22) },
            new Author { Id = 3, FullName = "Emma Williams", Email = "emma.w@example.com", JoinedDate = new DateTime(2023, 5, 10) },
            new Author { Id = 4, FullName = "David Martinez", Email = "david.m@example.com", JoinedDate = new DateTime(2023, 7, 8) },
            new Author { Id = 5, FullName = "Lisa Anderson", Email = "lisa.a@example.com", JoinedDate = new DateTime(2023, 9, 14) }
        );

        // Seed Data: ~25 Posts distributed across authors
        modelBuilder.Entity<Post>().HasData(
            // Sarah's posts (6 posts)
            new Post { Id = 1, AuthorId = 1, Title = "Getting Started with ASP.NET Core", Content = "A comprehensive guide to building modern web applications...", PublishedDate = new DateTime(2024, 1, 10), IsPublished = true },
            new Post { Id = 2, AuthorId = 1, Title = "Understanding Entity Framework", Content = "Deep dive into EF Core relationships and migrations...", PublishedDate = new DateTime(2024, 2, 5), IsPublished = true },
            new Post { Id = 3, AuthorId = 1, Title = "REST API Best Practices", Content = "Learn how to design clean and maintainable APIs...", PublishedDate = new DateTime(2024, 3, 12), IsPublished = true },
            new Post { Id = 4, AuthorId = 1, Title = "Async Programming in C#", Content = "Master async/await patterns for better performance...", PublishedDate = new DateTime(2024, 4, 20), IsPublished = true },
            new Post { Id = 5, AuthorId = 1, Title = "Dependency Injection Explained", Content = "Understanding DI containers and service lifetimes...", PublishedDate = new DateTime(2024, 5, 8), IsPublished = true },
            new Post { Id = 6, AuthorId = 1, Title = "Draft: Advanced LINQ Queries", Content = "Work in progress on complex query patterns...", PublishedDate = new DateTime(2024, 6, 1), IsPublished = false },
            // Michael's posts (5 posts)
            new Post { Id = 7, AuthorId = 2, Title = "Docker for .NET Developers", Content = "Containerize your applications with Docker...", PublishedDate = new DateTime(2024, 1, 25), IsPublished = true },
            new Post { Id = 8, AuthorId = 2, Title = "Microservices Architecture", Content = "Building scalable distributed systems...", PublishedDate = new DateTime(2024, 3, 5), IsPublished = true },
            new Post { Id = 9, AuthorId = 2, Title = "Kubernetes Basics", Content = "Orchestrating containers in production...", PublishedDate = new DateTime(2024, 4, 15), IsPublished = true },
            new Post { Id = 10, AuthorId = 2, Title = "CI/CD with GitHub Actions", Content = "Automating your deployment pipeline...", PublishedDate = new DateTime(2024, 5, 22), IsPublished = true },
            new Post { Id = 11, AuthorId = 2, Title = "Draft: Service Mesh Patterns", Content = "Exploring Istio and service mesh...", PublishedDate = new DateTime(2024, 6, 10), IsPublished = false },

            // Emma's posts (5 posts)
            new Post { Id = 12, AuthorId = 3, Title = "React Hooks Tutorial", Content = "Modern React development with hooks...", PublishedDate = new DateTime(2024, 2, 8), IsPublished = true },
            new Post { Id = 13, AuthorId = 3, Title = "TypeScript for Beginners", Content = "Adding type safety to your JavaScript...", PublishedDate = new DateTime(2024, 3, 18), IsPublished = true },
            new Post { Id = 14, AuthorId = 3, Title = "State Management with Redux", Content = "Managing complex application state...", PublishedDate = new DateTime(2024, 4, 25), IsPublished = true },
            new Post { Id = 15, AuthorId = 3, Title = "Next.js Full Stack Apps", Content = "Building modern web apps with Next.js...", PublishedDate = new DateTime(2024, 5, 30), IsPublished = true },
            new Post { Id = 16, AuthorId = 3, Title = "CSS Grid and Flexbox", Content = "Modern layout techniques for responsive design...", PublishedDate = new DateTime(2024, 6, 12), IsPublished = true },

            // David's posts (5 posts)
            new Post { Id = 17, AuthorId = 4, Title = "Python Data Science Basics", Content = "Getting started with pandas and numpy...", PublishedDate = new DateTime(2024, 2, 14), IsPublished = true },
            new Post { Id = 18, AuthorId = 4, Title = "Machine Learning with TensorFlow", Content = "Building neural networks from scratch...", PublishedDate = new DateTime(2024, 3, 28), IsPublished = true },
            new Post { Id = 19, AuthorId = 4, Title = "SQL Query Optimization", Content = "Writing efficient database queries...", PublishedDate = new DateTime(2024, 4, 10), IsPublished = true },
            new Post { Id = 20, AuthorId = 4, Title = "NoSQL vs SQL Databases", Content = "Choosing the right database for your needs...", PublishedDate = new DateTime(2024, 5, 18), IsPublished = true },
            new Post { Id = 21, AuthorId = 4, Title = "Draft: Big Data Processing", Content = "Working with Apache Spark...", PublishedDate = new DateTime(2024, 6, 5), IsPublished = false },

            // Lisa's posts (4 posts)
            new Post { Id = 22, AuthorId = 5, Title = "Agile Development Practices", Content = "Implementing Scrum in your team...", PublishedDate = new DateTime(2024, 3, 8), IsPublished = true },
            new Post { Id = 23, AuthorId = 5, Title = "Code Review Best Practices", Content = "Improving code quality through reviews...", PublishedDate = new DateTime(2024, 4, 12), IsPublished = true },
            new Post { Id = 24, AuthorId = 5, Title = "Technical Debt Management", Content = "Balancing features and maintainability...", PublishedDate = new DateTime(2024, 5, 20), IsPublished = true },
            new Post { Id = 25, AuthorId = 5, Title = "Team Leadership Skills", Content = "Growing from developer to tech lead...", PublishedDate = new DateTime(2024, 6, 8), IsPublished = true }
        );

        // Seed Data: ~75 Comments distributed across posts
        var comments = new List<Comment>();
        int commentId = 1;

        // Post 1: 5 comments
        comments.AddRange(new[] {
            new Comment { Id = commentId++, PostId = 1, CommenterName = "John Doe", Text = "Great introduction! Very helpful for beginners.", CreatedAt = new DateTime(2024, 1, 11, 10, 30, 0) },
            new Comment { Id = commentId++, PostId = 1, CommenterName = "Jane Smith", Text = "Could you cover middleware in the next post?", CreatedAt = new DateTime(2024, 1, 11, 14, 15, 0) },
            new Comment { Id = commentId++, PostId = 1, CommenterName = "Bob Wilson", Text = "This helped me get started with my first project!", CreatedAt = new DateTime(2024, 1, 12, 9, 20, 0) },
            new Comment { Id = commentId++, PostId = 1, CommenterName = "Alice Brown", Text = "Clear explanations, thank you!", CreatedAt = new DateTime(2024, 1, 13, 16, 45, 0) },
            new Comment { Id = commentId++, PostId = 1, CommenterName = "Charlie Davis", Text = "Looking forward to more ASP.NET content.", CreatedAt = new DateTime(2024, 1, 14, 11, 10, 0) }
        });

        // Post 2: 4 comments
        comments.AddRange(new[] {
            new Comment { Id = commentId++, PostId = 2, CommenterName = "Emily White", Text = "EF Core migrations can be tricky, thanks for this!", CreatedAt = new DateTime(2024, 2, 6, 8, 30, 0) },
            new Comment { Id = commentId++, PostId = 2, CommenterName = "Frank Miller", Text = "What about many-to-many relationships?", CreatedAt = new DateTime(2024, 2, 7, 13, 20, 0) },
            new Comment { Id = commentId++, PostId = 2, CommenterName = "Grace Lee", Text = "Very detailed explanation of relationships.", CreatedAt = new DateTime(2024, 2, 8, 10, 15, 0) },
            new Comment { Id = commentId++, PostId = 2, CommenterName = "Henry Taylor", Text = "This solved my foreign key issues!", CreatedAt = new DateTime(2024, 2, 9, 15, 40, 0) }
        });

        // Post 3: 3 comments
        comments.AddRange(new[] {
            new Comment { Id = commentId++, PostId = 3, CommenterName = "Ivy Chen", Text = "REST principles explained perfectly.", CreatedAt = new DateTime(2024, 3, 13, 9, 10, 0) },
            new Comment { Id = commentId++, PostId = 3, CommenterName = "Jack Robinson", Text = "How do you handle versioning?", CreatedAt = new DateTime(2024, 3, 14, 14, 25, 0) },
            new Comment { Id = commentId++, PostId = 3, CommenterName = "Kelly Martinez", Text = "Bookmarked for future reference!", CreatedAt = new DateTime(2024, 3, 15, 11, 50, 0) }
        });

        // Post 4: 4 comments
        comments.AddRange(new[] {
            new Comment { Id = commentId++, PostId = 4, CommenterName = "Leo Garcia", Text = "Async/await finally makes sense!", CreatedAt = new DateTime(2024, 4, 21, 10, 5, 0) },
            new Comment { Id = commentId++, PostId = 4, CommenterName = "Mia Anderson", Text = "Great examples of common pitfalls.", CreatedAt = new DateTime(2024, 4, 22, 13, 30, 0) },
            new Comment { Id = commentId++, PostId = 4, CommenterName = "Noah Thomas", Text = "Could you cover Task.WhenAll?", CreatedAt = new DateTime(2024, 4, 23, 9, 45, 0) },
            new Comment { Id = commentId++, PostId = 4, CommenterName = "Olivia Jackson", Text = "This improved my app's performance significantly.", CreatedAt = new DateTime(2024, 4, 24, 16, 20, 0) }
        });

        // Post 5: 3 comments
        comments.AddRange(new[] {
            new Comment { Id = commentId++, PostId = 5, CommenterName = "Paul Harris", Text = "DI was confusing until I read this.", CreatedAt = new DateTime(2024, 5, 9, 8, 15, 0) },
            new Comment { Id = commentId++, PostId = 5, CommenterName = "Quinn Martin", Text = "Service lifetimes explained clearly!", CreatedAt = new DateTime(2024, 5, 10, 12, 40, 0) },
            new Comment { Id = commentId++, PostId = 5, CommenterName = "Rachel Thompson", Text = "Very practical examples.", CreatedAt = new DateTime(2024, 5, 11, 15, 10, 0) }
        });

        // Post 7: 4 comments
        comments.AddRange(new[] {
            new Comment { Id = commentId++, PostId = 7, CommenterName = "Sam White", Text = "Docker has been on my learning list, perfect timing!", CreatedAt = new DateTime(2024, 1, 26, 9, 20, 0) },
            new Comment { Id = commentId++, PostId = 7, CommenterName = "Tina Lopez", Text = "Multi-stage builds are a game changer.", CreatedAt = new DateTime(2024, 1, 27, 14, 35, 0) },
            new Comment { Id = commentId++, PostId = 7, CommenterName = "Uma Patel", Text = "How do you handle secrets in containers?", CreatedAt = new DateTime(2024, 1, 28, 10, 50, 0) },
            new Comment { Id = commentId++, PostId = 7, CommenterName = "Victor Kim", Text = "Great Docker tutorial!", CreatedAt = new DateTime(2024, 1, 29, 16, 15, 0) }
        });

        // Post 8: 3 comments
        comments.AddRange(new[] {
            new Comment { Id = commentId++, PostId = 8, CommenterName = "Wendy Clark", Text = "Microservices architecture explained well.", CreatedAt = new DateTime(2024, 3, 6, 11, 10, 0) },
            new Comment { Id = commentId++, PostId = 8, CommenterName = "Xavier Rodriguez", Text = "What about service discovery?", CreatedAt = new DateTime(2024, 3, 7, 13, 25, 0) },
            new Comment { Id = commentId++, PostId = 8, CommenterName = "Yara Lewis", Text = "This helped me design my system.", CreatedAt = new DateTime(2024, 3, 8, 15, 40, 0) }
        });

        // Post 9: 3 comments
        comments.AddRange(new[] {
            new Comment { Id = commentId++, PostId = 9, CommenterName = "Zack Walker", Text = "Kubernetes is complex but this helps!", CreatedAt = new DateTime(2024, 4, 16, 9, 30, 0) },
            new Comment { Id = commentId++, PostId = 9, CommenterName = "Amy Hall", Text = "Deployments and services explained clearly.", CreatedAt = new DateTime(2024, 4, 17, 12, 15, 0) },
            new Comment { Id = commentId++, PostId = 9, CommenterName = "Ben Allen", Text = "Looking forward to advanced K8s topics.", CreatedAt = new DateTime(2024, 4, 18, 14, 50, 0) }
        });

        // Post 10: 4 comments
        comments.AddRange(new[] {
            new Comment { Id = commentId++, PostId = 10, CommenterName = "Cara Young", Text = "GitHub Actions workflow examples are great!", CreatedAt = new DateTime(2024, 5, 23, 10, 20, 0) },
            new Comment { Id = commentId++, PostId = 10, CommenterName = "Dan King", Text = "How do you handle deployment secrets?", CreatedAt = new DateTime(2024, 5, 24, 13, 45, 0) },
            new Comment { Id = commentId++, PostId = 10, CommenterName = "Eva Wright", Text = "Automated my entire pipeline thanks to this!", CreatedAt = new DateTime(2024, 5, 25, 11, 10, 0) },
            new Comment { Id = commentId++, PostId = 10, CommenterName = "Fred Scott", Text = "CI/CD made simple.", CreatedAt = new DateTime(2024, 5, 26, 15, 30, 0) }
        });

        // Post 12: 3 comments
        comments.AddRange(new[] {
            new Comment { Id = commentId++, PostId = 12, CommenterName = "Gina Green", Text = "React hooks changed everything!", CreatedAt = new DateTime(2024, 2, 9, 9, 15, 0) },
            new Comment { Id = commentId++, PostId = 12, CommenterName = "Hank Adams", Text = "useState and useEffect explained perfectly.", CreatedAt = new DateTime(2024, 2, 10, 12, 30, 0) },
            new Comment { Id = commentId++, PostId = 12, CommenterName = "Iris Baker", Text = "Custom hooks tutorial next please!", CreatedAt = new DateTime(2024, 2, 11, 14, 45, 0) }
        });

        // Post 13: 4 comments
        comments.AddRange(new[] {
            new Comment { Id = commentId++, PostId = 13, CommenterName = "Jake Nelson", Text = "TypeScript makes JavaScript so much better.", CreatedAt = new DateTime(2024, 3, 19, 10, 10, 0) },
            new Comment { Id = commentId++, PostId = 13, CommenterName = "Kate Carter", Text = "Type safety is a lifesaver!", CreatedAt = new DateTime(2024, 3, 20, 13, 20, 0) },
            new Comment { Id = commentId++, PostId = 13, CommenterName = "Liam Mitchell", Text = "Generics explained clearly.", CreatedAt = new DateTime(2024, 3, 21, 11, 35, 0) },
            new Comment { Id = commentId++, PostId = 13, CommenterName = "Maya Perez", Text = "Switching all my projects to TS now.", CreatedAt = new DateTime(2024, 3, 22, 15, 50, 0) }
        });

        // Post 14: 3 comments
        comments.AddRange(new[] {
            new Comment { Id = commentId++, PostId = 14, CommenterName = "Nick Roberts", Text = "Redux Toolkit makes state management easier.", CreatedAt = new DateTime(2024, 4, 26, 9, 25, 0) },
            new Comment { Id = commentId++, PostId = 14, CommenterName = "Olga Turner", Text = "What about Zustand as an alternative?", CreatedAt = new DateTime(2024, 4, 27, 12, 40, 0) },
            new Comment { Id = commentId++, PostId = 14, CommenterName = "Pete Phillips", Text = "Great Redux tutorial!", CreatedAt = new DateTime(2024, 4, 28, 14, 15, 0) }
        });

        // Post 15: 4 comments
        comments.AddRange(new[] {
            new Comment { Id = commentId++, PostId = 15, CommenterName = "Rita Campbell", Text = "Next.js is amazing for full stack apps.", CreatedAt = new DateTime(2024, 5, 31, 10, 5, 0) },
            new Comment { Id = commentId++, PostId = 15, CommenterName = "Steve Parker", Text = "Server components are the future!", CreatedAt = new DateTime(2024, 6, 1, 13, 20, 0) },
            new Comment { Id = commentId++, PostId = 15, CommenterName = "Tara Evans", Text = "SEO benefits are huge.", CreatedAt = new DateTime(2024, 6, 2, 11, 45, 0) },
            new Comment { Id = commentId++, PostId = 15, CommenterName = "Umar Edwards", Text = "Deploying to Vercel is so easy!", CreatedAt = new DateTime(2024, 6, 3, 15, 10, 0) }
        });

        // Post 16: 3 comments
        comments.AddRange(new[] {
            new Comment { Id = commentId++, PostId = 16, CommenterName = "Vera Collins", Text = "CSS Grid is so powerful!", CreatedAt = new DateTime(2024, 6, 13, 9, 30, 0) },
            new Comment { Id = commentId++, PostId = 16, CommenterName = "Will Stewart", Text = "Flexbox vs Grid comparison would be great.", CreatedAt = new DateTime(2024, 6, 14, 12, 15, 0) },
            new Comment { Id = commentId++, PostId = 16, CommenterName = "Xena Morris", Text = "Responsive layouts made easy!", CreatedAt = new DateTime(2024, 6, 15, 14, 40, 0) }
        });

        // Post 17: 3 comments
        comments.AddRange(new[] {
            new Comment { Id = commentId++, PostId = 17, CommenterName = "Yuri Rogers", Text = "Pandas is essential for data science.", CreatedAt = new DateTime(2024, 2, 15, 10, 20, 0) },
            new Comment { Id = commentId++, PostId = 17, CommenterName = "Zoe Reed", Text = "DataFrame operations explained well.", CreatedAt = new DateTime(2024, 2, 16, 13, 35, 0) },
            new Comment { Id = commentId++, PostId = 17, CommenterName = "Adam Cook", Text = "Great intro to Python data science!", CreatedAt = new DateTime(2024, 2, 17, 11, 50, 0) }
        });

        // Post 18: 4 comments
        comments.AddRange(new[] {
            new Comment { Id = commentId++, PostId = 18, CommenterName = "Beth Morgan", Text = "TensorFlow tutorial is comprehensive.", CreatedAt = new DateTime(2024, 3, 29, 9, 10, 0) },
            new Comment { Id = commentId++, PostId = 18, CommenterName = "Carl Bell", Text = "Neural networks finally make sense!", CreatedAt = new DateTime(2024, 3, 30, 12, 25, 0) },
            new Comment { Id = commentId++, PostId = 18, CommenterName = "Dana Murphy", Text = "Could you cover CNNs next?", CreatedAt = new DateTime(2024, 3, 31, 14, 40, 0) },
            new Comment { Id = commentId++, PostId = 18, CommenterName = "Eric Bailey", Text = "ML is less intimidating now.", CreatedAt = new DateTime(2024, 4, 1, 16, 15, 0) }
        });

        // Post 19: 3 comments
        comments.AddRange(new[] {
            new Comment { Id = commentId++, PostId = 19, CommenterName = "Faye Rivera", Text = "Query optimization tips are gold!", CreatedAt = new DateTime(2024, 4, 11, 10, 30, 0) },
            new Comment { Id = commentId++, PostId = 19, CommenterName = "Greg Cooper", Text = "Indexes explained clearly.", CreatedAt = new DateTime(2024, 4, 12, 13, 45, 0) },
            new Comment { Id = commentId++, PostId = 19, CommenterName = "Hope Richardson", Text = "My queries are 10x faster now!", CreatedAt = new DateTime(2024, 4, 13, 15, 20, 0) }
        });

        // Post 20: 4 comments
        comments.AddRange(new[] {
            new Comment { Id = commentId++, PostId = 20, CommenterName = "Ian Cox", Text = "Great comparison of database types.", CreatedAt = new DateTime(2024, 5, 19, 9, 15, 0) },
            new Comment { Id = commentId++, PostId = 20, CommenterName = "Jill Howard", Text = "When to use MongoDB vs PostgreSQL?", CreatedAt = new DateTime(2024, 5, 20, 12, 30, 0) },
            new Comment { Id = commentId++, PostId = 20, CommenterName = "Kyle Ward", Text = "This helped me choose the right DB.", CreatedAt = new DateTime(2024, 5, 21, 14, 45, 0) },
            new Comment { Id = commentId++, PostId = 20, CommenterName = "Lynn Torres", Text = "Very informative article!", CreatedAt = new DateTime(2024, 5, 22, 16, 10, 0) }
        });

        // Post 22: 3 comments
        comments.AddRange(new[] {
            new Comment { Id = commentId++, PostId = 22, CommenterName = "Mark Peterson", Text = "Scrum practices explained well.", CreatedAt = new DateTime(2024, 3, 9, 10, 20, 0) },
            new Comment { Id = commentId++, PostId = 22, CommenterName = "Nina Gray", Text = "Our team adopted these practices!", CreatedAt = new DateTime(2024, 3, 10, 13, 35, 0) },
            new Comment { Id = commentId++, PostId = 22, CommenterName = "Owen Ramirez", Text = "Agile methodology made simple.", CreatedAt = new DateTime(2024, 3, 11, 15, 50, 0) }
        });

        // Post 23: 4 comments
        comments.AddRange(new[] {
            new Comment { Id = commentId++, PostId = 23, CommenterName = "Pam James", Text = "Code reviews are so important!", CreatedAt = new DateTime(2024, 4, 13, 9, 25, 0) },
            new Comment { Id = commentId++, PostId = 23, CommenterName = "Quinn Watson", Text = "Great tips for constructive feedback.", CreatedAt = new DateTime(2024, 4, 14, 12, 40, 0) },
            new Comment { Id = commentId++, PostId = 23, CommenterName = "Ross Brooks", Text = "Our code quality improved significantly.", CreatedAt = new DateTime(2024, 4, 15, 14, 15, 0) },
            new Comment { Id = commentId++, PostId = 23, CommenterName = "Sara Kelly", Text = "Every developer should read this.", CreatedAt = new DateTime(2024, 4, 16, 16, 30, 0) }
        });

        // Post 24: 3 comments
        comments.AddRange(new[] {
            new Comment { Id = commentId++, PostId = 24, CommenterName = "Tony Sanders", Text = "Technical debt is real!", CreatedAt = new DateTime(2024, 5, 21, 10, 10, 0) },
            new Comment { Id = commentId++, PostId = 24, CommenterName = "Uma Price", Text = "Balancing features and refactoring is hard.", CreatedAt = new DateTime(2024, 5, 22, 13, 25, 0) },
            new Comment { Id = commentId++, PostId = 24, CommenterName = "Vince Bennett", Text = "Practical advice for managing debt.", CreatedAt = new DateTime(2024, 5, 23, 15, 40, 0) }
        });

        // Post 25: 4 comments
        comments.AddRange(new[] {
            new Comment { Id = commentId++, PostId = 25, CommenterName = "Wanda Wood", Text = "Leadership skills are crucial!", CreatedAt = new DateTime(2024, 6, 9, 9, 30, 0) },
            new Comment { Id = commentId++, PostId = 25, CommenterName = "Xavier Barnes", Text = "Transitioning to tech lead soon, this helps!", CreatedAt = new DateTime(2024, 6, 10, 12, 15, 0) },
            new Comment { Id = commentId++, PostId = 25, CommenterName = "Yolanda Ross", Text = "Great insights on team leadership.", CreatedAt = new DateTime(2024, 6, 11, 14, 40, 0) },
            new Comment { Id = commentId++, PostId = 25, CommenterName = "Zane Henderson", Text = "Every tech lead should read this.", CreatedAt = new DateTime(2024, 6, 12, 16, 20, 0) }
        });


         modelBuilder.Entity<Comment>().HasData(comments);

    }






}