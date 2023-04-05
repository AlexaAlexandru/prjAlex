using System;
using System.ComponentModel.DataAnnotations;
using SchedulePlatform.Models.Enums;

namespace SchedulePlatform.Service.Models.ServiceProvided
{
	public class ServiceProvidedRequestModel
	{
        public Guid Id = Guid.NewGuid();
        [StringLength(250,MinimumLength =10,ErrorMessage ="The description of the service should have at least 10 maxim 250 characters")]
        public string? Description { get; set; }
        [MinLength(2,ErrorMessage ="The name of the service should have at least 2 characters")]
        public string? NameServiceProvided { get; set; }
        public Uri? UrlPicture { get; set; }
        public ConsultationType Type { get; set; }
        [DataType(DataType.Currency)]
        [Range(1,1000,ErrorMessage ="Price should be between 1 and 1000")]
        public double Price { get; set; }
    }
}

