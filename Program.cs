using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FrameworkLab.DataLayer;
using FrameworkLab.Entities;
using FrameworkLab.Infrastructure;
using FrameworkLab.Models;
using FrameworkLab.Validators;
using Microsoft.EntityFrameworkCore;

namespace FrameworkLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            InitializeMappings();

            Create();

            Edit();

            View();

            Validate();

            Console.ReadKey();
        }

        private static void InitializeMappings()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<MasterModel, Master>(MemberList.None).ReverseMap();
                expression.CreateMap<DetailModel, Detail>(MemberList.None).ReverseMap();
                expression.CreateMap<DetailOfDetailModel, DetailOfDetail>(MemberList.None).ReverseMap();
            });
        }

        private static void Validate()
        {
            Console.WriteLine(
                "################ MasterModelValidator ##################");
            var model = new MasterModel
            {
                Title = "Master-Title",
                TrackingState = TrackingState.Added,
                Details = new List<DetailModel>
                {
                    new DetailModel
                    {
                        Title = "Detail-Title",
                        TrackingState = TrackingState.Added,
                        Details = new List<DetailOfDetailModel>
                        {
                            new DetailOfDetailModel
                            {
                                Title = string.Empty,
                                TrackingState = TrackingState.Added,
                            }
                        }
                    }
                }
            };

            var validator = new MasterValidator();
            var result = validator.Validate(model);
            foreach (var error in result.Errors)
            {
                Console.WriteLine($"property: {error.PropertyName}\nmessage: {error.ErrorMessage}");
            }
        }

        private static void View()
        {
            using (var context = new ProjectDbContext())
            {
                var masterModel = context.Masters
                    .ProjectTo<MasterModel>()
                    .AsNoTracking().Single(a => a.Id == 1);

                Console.WriteLine(
                    "################ Unchanged Master and Unchanged Details and Empty DetailsOfDetail ##################");

                Print(masterModel);
            }
        }

        private static void Edit()
        {
            MasterModel masterModel;

            using (var context = new ProjectDbContext())
            {
                masterModel = context.Masters
                    .ProjectTo<MasterModel>()
                    .AsNoTracking().Single(a => a.Id == 1);

                var detail1 = masterModel.Details.First();
                detail1.Title = "Details-EditedTitle";
                detail1.TrackingState = TrackingState.Modified;

                foreach (var detail in detail1.Details)
                {
                    detail.TrackingState = TrackingState.Deleted;
                    //detail.Title = "DetailOfDetails-EditedTitle";
                }

                Console.WriteLine(
                    "################ Unchanged Master and Modified Details and Deleted DetailsOfDetail ##################");
                Print(masterModel);


                var masterEntity = Mapper.Map<Master>(masterModel);

                context.SaveAggregate(masterEntity);
            }
        }

        private static void Create()
        {
            var masterModel = new MasterModel
            {
                Title = "Master-Title",
                TrackingState = TrackingState.Added,
                Details = new List<DetailModel>
                {
                    new DetailModel
                    {
                        Title = "Detail-Title",
                        TrackingState = TrackingState.Added,
                        Details = new List<DetailOfDetailModel>
                        {
                            new DetailOfDetailModel
                            {
                                Title = "DetailOfDetail-Title",
                                TrackingState = TrackingState.Added,
                            }
                        }
                    }
                }
            };

            Console.WriteLine("################ Create Master and Details and DetailsOfDetail ##################");
            Print(masterModel);

            var masterEntity = Mapper.Map<Master>(masterModel);

            using (var context = new ProjectDbContext())
            {
                context.SaveAggregate(masterEntity);
            }
        }

        private static void Print(MasterModel masterModel)
        {
            Console.WriteLine(
                $"{masterModel.Title}, State: {masterModel.TrackingState}, DetailsCount:{masterModel.Details?.Count}");
            foreach (var detail in masterModel.Details)
            {
                Console.WriteLine(
                    $"--{detail.Title}, State: {detail.TrackingState}, DetailsCount:{detail.Details?.Count}");
                foreach (var detailOfDetail in detail.Details)
                {
                    Console.WriteLine($"----{detail.Title}, State: {detailOfDetail.TrackingState}");
                }
            }
        }
    }
}