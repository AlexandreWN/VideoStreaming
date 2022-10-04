using System;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    public partial class Content
    {
        public int Id { get; set; }
        public byte[] Bytes { get; set; } = null!;
    }
}

