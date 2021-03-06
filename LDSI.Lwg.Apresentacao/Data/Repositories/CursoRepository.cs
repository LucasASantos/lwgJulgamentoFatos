﻿using System.Linq;
using System.Security.Cryptography.X509Certificates;
using LDSI.Lwg.Apresentacao.Data.Context;
using LDSI.Lwg.Apresentacao.Data.Repositories.Interfaces;
using LDSI.Lwg.Apresentacao.Models;

namespace LDSI.Lwg.Apresentacao.Data.Repositories
{
  public class CursoRepository: Repository<Curso>, ICursoRepository
  {
    public CursoRepository(ApplicationDbContext context) : base(context)
    {
    }
  }
}