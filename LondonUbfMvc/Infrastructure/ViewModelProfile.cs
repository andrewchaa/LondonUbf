using AutoMapper;
using LondonUbfWeb.Domain.Models;

namespace LondonUbfWeb.Infrastructure
{
    public class ViewModelProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModel"; }
        }

        protected override void Configure()
        {
            CreateMap<Job, JobListViewModel>()
                .ForMember(t => t.Date, opt => opt.MapFrom(s => s.Date.ToString("dd/MM/yyyy")))
                .ForMember(t => t.Messenger, opt => opt.MapFrom(s => s.Messenger.Firstname))
                .ForMember(t => t.Presider, opt => opt.MapFrom(s => s.Presider.Firstname))
                .ForMember(t => t.Reader, opt => opt.MapFrom(s => s.Reader.Firstname))
                .ForMember(t => t.PrayerServantMan, opt => opt.MapFrom(s => s.PrayerServantMan.Firstname))
                .ForMember(t => t.PrayerServantWoman, opt => opt.MapFrom(s => s.PrayerServantWoman.Firstname))
                ;

            CreateMap<Lecture, LectureInput>()
                .ForMember(t => t.IsoDeliveryDate, opt => opt.MapFrom(s => s.DeliveryDate.ToString("yyyy-MM-dd")));
            CreateMap<Lecture, LectureViewModel>()
                .ForMember(t => t.Year, opt => opt.MapFrom(s => s.DeliveryDate.Year))
                .ForMember(t => t.ContentHtml, opt => opt.MapFrom(s => s.Content.Replace("\r\n", "<br />")))
                .ForMember(t => t.DeliveryDate, opt => opt.MapFrom(s => s.DeliveryDate.ToString("dd/MM/yyyy")))
                ;

            CreateMap<Person, PersonListViewModel>()
                .ForMember(c => c.Name, opt => opt.MapFrom(s => s.Firstname + " " + s.Lastname));
            CreateMap<Person, PersonInput>();
        }
    }
}