﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.APIs
{
  public class HotelDto
  {
    public int Id { get; set; }    
    public string Name { get; set; }    
    public string StreetAddress { get; set; }    
    public string City { get; set; }    
    public string State { get; set; }
    public string Phone { get; set; }
    public List<HotelRoomDto> Rooms { get; set; }
       
  }
}
