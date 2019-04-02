﻿// <auto-generated />
using System;
using LDSI.Lwg.Apresentacao.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LDSI.Lwg.Apresentacao.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190402172009_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity("LDSI.Lwg.Apresentacao.Models.AlunoTurma", b =>
                {
                    b.Property<string>("AlunoId");

                    b.Property<byte[]>("TurmaId")
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.HasKey("AlunoId", "TurmaId");

                    b.HasIndex("TurmaId");

                    b.ToTable("AlunoTurma");
                });

            modelBuilder.Entity("LDSI.Lwg.Apresentacao.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(80);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<byte[]>("CursoId")
                        .IsRequired()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Nome");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("LDSI.Lwg.Apresentacao.Models.Curso", b =>
                {
                    b.Property<byte[]>("CursoId")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<string>("Nome");

                    b.Property<string>("Unidade");

                    b.HasKey("CursoId");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("LDSI.Lwg.Apresentacao.Models.Disciplina", b =>
                {
                    b.Property<byte[]>("DisciplinaId")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<byte[]>("CursoId")
                        .IsRequired()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<string>("Nome");

                    b.HasKey("DisciplinaId");

                    b.HasIndex("CursoId");

                    b.ToTable("Disciplina");
                });

            modelBuilder.Entity("LDSI.Lwg.Apresentacao.Models.Equipe", b =>
                {
                    b.Property<byte[]>("EquipeId")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.HasKey("EquipeId");

                    b.ToTable("Equipe");
                });

            modelBuilder.Entity("LDSI.Lwg.Apresentacao.Models.Fato", b =>
                {
                    b.Property<byte[]>("FatoId")
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<byte[]>("JulgamentoFatosId")
                        .IsRequired()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<int>("Ordem");

                    b.Property<string>("Texto");

                    b.Property<string>("Topicos");

                    b.Property<bool>("Verdadeiro");

                    b.HasKey("FatoId");

                    b.ToTable("Fato");
                });

            modelBuilder.Entity("LDSI.Lwg.Apresentacao.Models.Integrante", b =>
                {
                    b.Property<byte[]>("IntegranteId")
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<bool>("EhLider");

                    b.Property<byte[]>("EquipeId")
                        .IsRequired()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<string>("UserId");

                    b.HasKey("IntegranteId");

                    b.HasIndex("UserId");

                    b.ToTable("Integrante");
                });

            modelBuilder.Entity("LDSI.Lwg.Apresentacao.Models.JulgamentoFatos", b =>
                {
                    b.Property<byte[]>("JulgamentoFatosId")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<int>("Status");

                    b.Property<int>("TamanhoEquipe");

                    b.Property<TimeSpan>("TempoExibicao");

                    b.Property<string>("UserId");

                    b.HasKey("JulgamentoFatosId");

                    b.HasIndex("UserId");

                    b.ToTable("JulgamentoFatos");
                });

            modelBuilder.Entity("LDSI.Lwg.Apresentacao.Models.Resposta", b =>
                {
                    b.Property<byte[]>("RespostaId")
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<byte[]>("EqupeId")
                        .IsRequired()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<byte[]>("FatoId")
                        .IsRequired()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<bool>("FatoVerdadeiro");

                    b.HasKey("RespostaId");

                    b.HasIndex("EqupeId");

                    b.ToTable("Resposta");
                });

            modelBuilder.Entity("LDSI.Lwg.Apresentacao.Models.Turma", b =>
                {
                    b.Property<byte[]>("TurmaId")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<string>("Codigo");

                    b.Property<byte[]>("DisciplinaId")
                        .IsRequired()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<string>("UserId");

                    b.HasKey("TurmaId");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("UserId");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(80);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(80);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(80);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(80);

                    b.Property<string>("RoleId")
                        .HasMaxLength(80);

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(80);

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("LDSI.Lwg.Apresentacao.Models.AlunoTurma", b =>
                {
                    b.HasOne("LDSI.Lwg.Apresentacao.Models.ApplicationUser", "Aluno")
                        .WithMany("AlunosTurmas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LDSI.Lwg.Apresentacao.Models.Turma", "Turma")
                        .WithMany("AlunosTurmas")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LDSI.Lwg.Apresentacao.Models.ApplicationUser", b =>
                {
                    b.HasOne("LDSI.Lwg.Apresentacao.Models.Curso", "Curso")
                        .WithMany("Alunos")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LDSI.Lwg.Apresentacao.Models.Disciplina", b =>
                {
                    b.HasOne("LDSI.Lwg.Apresentacao.Models.Curso", "Curso")
                        .WithMany("Disciplinas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LDSI.Lwg.Apresentacao.Models.Fato", b =>
                {
                    b.HasOne("LDSI.Lwg.Apresentacao.Models.JulgamentoFatos", "JulgamentoFatos")
                        .WithMany("Fatos")
                        .HasForeignKey("FatoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LDSI.Lwg.Apresentacao.Models.Integrante", b =>
                {
                    b.HasOne("LDSI.Lwg.Apresentacao.Models.Equipe", "Equipe")
                        .WithMany("Integrantes")
                        .HasForeignKey("IntegranteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LDSI.Lwg.Apresentacao.Models.ApplicationUser", "Aluno")
                        .WithMany("Intregracoes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("LDSI.Lwg.Apresentacao.Models.JulgamentoFatos", b =>
                {
                    b.HasOne("LDSI.Lwg.Apresentacao.Models.ApplicationUser", "Professor")
                        .WithMany("JulgamentosFatos")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("LDSI.Lwg.Apresentacao.Models.Resposta", b =>
                {
                    b.HasOne("LDSI.Lwg.Apresentacao.Models.Equipe", "Equipe")
                        .WithMany("Respostas")
                        .HasForeignKey("EqupeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LDSI.Lwg.Apresentacao.Models.Fato", "Fato")
                        .WithMany("Respostas")
                        .HasForeignKey("RespostaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LDSI.Lwg.Apresentacao.Models.Turma", b =>
                {
                    b.HasOne("LDSI.Lwg.Apresentacao.Models.Disciplina", "Disciplina")
                        .WithMany("Turmas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LDSI.Lwg.Apresentacao.Models.ApplicationUser", "Professor")
                        .WithMany("Turmas")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("LDSI.Lwg.Apresentacao.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("LDSI.Lwg.Apresentacao.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LDSI.Lwg.Apresentacao.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("LDSI.Lwg.Apresentacao.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
