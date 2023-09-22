using CoreLayer.Entities;
using System;


namespace EntityLayer.Concrete
{
	public class Slider : IEntity
	{
		public int Id { get; set; }
		public string Image { get; set; }
		public string Title { get; set; }
		public bool IsDeactive { get; set; }
	}
}
