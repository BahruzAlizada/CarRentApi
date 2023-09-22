using CoreLayer.Entities;
using System;

namespace EntityLayer.DTOs
{
	public class SliderDTO : IDto
	{
		public int Id { get; set; }
		public string Image { get; set; }
		public string Title { get; set; }
	}
}
