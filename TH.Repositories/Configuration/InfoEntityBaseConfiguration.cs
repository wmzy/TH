﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.Model;

namespace TH.Repositories.Configuration
{
    class InfoEntityBaseConfiguration : EntityTypeConfiguration<InfoBase>
    {
        public InfoEntityBaseConfiguration()
        {
            HasKey(info => info.Id);
        }
    }
}
