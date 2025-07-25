﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SimpleSpells.Data;

#nullable disable

namespace SimpleSpells.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SimpleSpells.Model.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Class")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SpellAtkBonus")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Class = 8,
                            Level = 1,
                            Name = "Aragorn",
                            SpellAtkBonus = 7
                        },
                        new
                        {
                            Id = 2,
                            Class = 5,
                            Level = 7,
                            Name = "Sandalphon",
                            SpellAtkBonus = 5
                        },
                        new
                        {
                            Id = 3,
                            Class = 3,
                            Level = 20,
                            Name = "Shabar",
                            SpellAtkBonus = 12
                        },
                        new
                        {
                            Id = 4,
                            Class = 12,
                            Level = 1,
                            Name = "Gale",
                            SpellAtkBonus = 6
                        });
                });

            modelBuilder.Entity("SimpleSpells.Model.CharacterSpell", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("integer");

                    b.Property<int>("SpellId")
                        .HasColumnType("integer");

                    b.HasKey("CharacterId", "SpellId");

                    b.HasIndex("SpellId");

                    b.ToTable("CharacterSpell");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            SpellId = 1
                        },
                        new
                        {
                            CharacterId = 1,
                            SpellId = 5
                        },
                        new
                        {
                            CharacterId = 1,
                            SpellId = 6
                        },
                        new
                        {
                            CharacterId = 2,
                            SpellId = 2
                        },
                        new
                        {
                            CharacterId = 3,
                            SpellId = 4
                        },
                        new
                        {
                            CharacterId = 3,
                            SpellId = 6
                        },
                        new
                        {
                            CharacterId = 3,
                            SpellId = 8
                        },
                        new
                        {
                            CharacterId = 3,
                            SpellId = 9
                        },
                        new
                        {
                            CharacterId = 4,
                            SpellId = 5
                        },
                        new
                        {
                            CharacterId = 4,
                            SpellId = 6
                        },
                        new
                        {
                            CharacterId = 4,
                            SpellId = 7
                        });
                });

            modelBuilder.Entity("SimpleSpells.Model.Spell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AOE")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Action")
                        .HasColumnType("integer");

                    b.Property<string>("Concentration")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Effect")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Hitcheck")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Range")
                        .HasColumnType("integer");

                    b.Property<string>("Requirements")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SpellLevel")
                        .HasColumnType("integer");

                    b.Property<string>("Targets")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Upcast")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Vsm")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Spells");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AOE = "",
                            Action = 1,
                            Concentration = "",
                            Effect = "{base=1D10} force damage",
                            Hitcheck = 1,
                            Name = "Eldritch blast{1}",
                            Range = 120,
                            Requirements = "",
                            SpellLevel = 0,
                            Targets = "1",
                            Upcast = "",
                            Url = "https://dnd5e.wikidot.com/spell:eldritch-blast",
                            Vsm = "V,S"
                        },
                        new
                        {
                            Id = 2,
                            AOE = "",
                            Action = 1,
                            Concentration = "",
                            Effect = "{base=1D10} force damage",
                            Hitcheck = 1,
                            Name = "Eldritch blast{5}",
                            Range = 120,
                            Requirements = "",
                            SpellLevel = 0,
                            Targets = "2",
                            Upcast = "",
                            Url = "https://dnd5e.wikidot.com/spell:eldritch-blast",
                            Vsm = "V,S"
                        },
                        new
                        {
                            Id = 3,
                            AOE = "",
                            Action = 1,
                            Concentration = "",
                            Effect = "{base=1D10} force damage",
                            Hitcheck = 1,
                            Name = "Eldritch blast{11}",
                            Range = 120,
                            Requirements = "",
                            SpellLevel = 0,
                            Targets = "3",
                            Upcast = "",
                            Url = "https://dnd5e.wikidot.com/spell:eldritch-blast",
                            Vsm = "V,S"
                        },
                        new
                        {
                            Id = 4,
                            AOE = "",
                            Action = 1,
                            Concentration = "",
                            Effect = "{base=1D10} force damage",
                            Hitcheck = 1,
                            Name = "Eldritch blast{17}",
                            Range = 120,
                            Requirements = "",
                            SpellLevel = 0,
                            Targets = "4",
                            Upcast = "",
                            Url = "https://dnd5e.wikidot.com/spell:eldritch-blast",
                            Vsm = "V,S"
                        },
                        new
                        {
                            Id = 5,
                            AOE = "",
                            Action = 1,
                            Concentration = "",
                            Effect = "-Push medium creature 5ft -Push object 10ft",
                            Hitcheck = 3,
                            Name = "Gust",
                            Range = 30,
                            Requirements = "",
                            SpellLevel = 0,
                            Targets = "1",
                            Upcast = "",
                            Url = "https://dnd5e.wikidot.com/spell:gust",
                            Vsm = "V,S"
                        },
                        new
                        {
                            Id = 6,
                            AOE = "",
                            Action = 1,
                            Concentration = "1 minute",
                            Effect = "d4 attack roll / saving throw bonus",
                            Hitcheck = 0,
                            Name = "Bless",
                            Range = 30,
                            Requirements = "",
                            SpellLevel = 1,
                            Targets = "3",
                            Upcast = "1 extra target",
                            Url = "https://dnd5e.wikidot.com/spell:bless",
                            Vsm = "V,S,M"
                        },
                        new
                        {
                            Id = 7,
                            AOE = "",
                            Action = 1,
                            Concentration = "",
                            Effect = "{Base: 3D8} acid/cold/fire/lightning/poison/thunder damage",
                            Hitcheck = 1,
                            Name = "Chromatic orb",
                            Range = 90,
                            Requirements = "50 GP diamond",
                            SpellLevel = 1,
                            Targets = "1",
                            Upcast = "{Base: 1d8} extra damage",
                            Url = "https://dnd5e.wikidot.com/spell:chromatic-orb",
                            Vsm = "V,S,M"
                        },
                        new
                        {
                            Id = 8,
                            AOE = "15ft square",
                            Action = 1,
                            Concentration = "10 minutes",
                            Effect = "Spawn 60ft cloud {Base: 3d10} lightning damage",
                            Hitcheck = 4,
                            Name = "Call lightning",
                            Range = 120,
                            Requirements = "Open sky",
                            SpellLevel = 3,
                            Targets = "1",
                            Upcast = "{Base: 1d10} extra damage",
                            Url = "https://dnd5e.wikidot.com/spell:call-lightning",
                            Vsm = "V,S"
                        },
                        new
                        {
                            Id = 9,
                            AOE = "40ft square",
                            Action = 1,
                            Concentration = "1 minute",
                            Effect = "Difficult terrain, Darkness, Thunder immunity, Deafened, {Base: 8d10} force damage",
                            Hitcheck = 5,
                            Name = "Dark star",
                            Range = 150,
                            Requirements = "",
                            SpellLevel = 8,
                            Targets = "",
                            Upcast = "",
                            Url = "https://dnd5e.wikidot.com/spell:dark-star",
                            Vsm = "V,S,M"
                        });
                });

            modelBuilder.Entity("SimpleSpells.Model.SpellSourceMapping", b =>
                {
                    b.Property<int>("SpellId")
                        .HasColumnType("integer");

                    b.Property<int>("Source")
                        .HasColumnType("integer");

                    b.HasKey("SpellId", "Source");

                    b.ToTable("SpellSourceMapping");

                    b.HasData(
                        new
                        {
                            SpellId = 1,
                            Source = 11
                        },
                        new
                        {
                            SpellId = 2,
                            Source = 11
                        },
                        new
                        {
                            SpellId = 3,
                            Source = 11
                        },
                        new
                        {
                            SpellId = 4,
                            Source = 11
                        },
                        new
                        {
                            SpellId = 5,
                            Source = 4
                        },
                        new
                        {
                            SpellId = 5,
                            Source = 10
                        },
                        new
                        {
                            SpellId = 5,
                            Source = 12
                        },
                        new
                        {
                            SpellId = 6,
                            Source = 3
                        },
                        new
                        {
                            SpellId = 6,
                            Source = 10
                        },
                        new
                        {
                            SpellId = 7,
                            Source = 12
                        },
                        new
                        {
                            SpellId = 7,
                            Source = 10
                        },
                        new
                        {
                            SpellId = 8,
                            Source = 4
                        },
                        new
                        {
                            SpellId = 9,
                            Source = 12
                        });
                });

            modelBuilder.Entity("SimpleSpells.Model.CharacterSpell", b =>
                {
                    b.HasOne("SimpleSpells.Model.Character", "Character")
                        .WithMany("CharacterSpells")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleSpells.Model.Spell", "Spell")
                        .WithMany()
                        .HasForeignKey("SpellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Spell");
                });

            modelBuilder.Entity("SimpleSpells.Model.SpellSourceMapping", b =>
                {
                    b.HasOne("SimpleSpells.Model.Spell", null)
                        .WithMany("Sources")
                        .HasForeignKey("SpellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SimpleSpells.Model.Character", b =>
                {
                    b.Navigation("CharacterSpells");
                });

            modelBuilder.Entity("SimpleSpells.Model.Spell", b =>
                {
                    b.Navigation("Sources");
                });
#pragma warning restore 612, 618
        }
    }
}
