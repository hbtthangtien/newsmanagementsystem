﻿using Persistences.Enum;
using System;
using System.Collections.Generic;

namespace Persistences.Entities;

public partial class SystemAccount
{
    public short AccountId { get; set; }

    public string? AccountName { get; set; }

    public string? AccountEmail { get; set; }

    public UserRole? AccountRole { get; set; }

    public string? AccountPassword { get; set; }

    public SystemStatus? AccountStatus { get; set; }

    public virtual ICollection<NewsArticle> NewsArticles { get; set; } = new List<NewsArticle>();
}
