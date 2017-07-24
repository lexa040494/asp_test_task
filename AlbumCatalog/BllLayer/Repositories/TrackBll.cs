using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BllLayer.Interfaces;
using DalLayer.Factory.Interfaces;
using Model;
using ViewModel.Models;

namespace BllLayer.Repositories
{
    public class TrackBll : ITrackBll
    {
        private IDalFactory _dalFactory;

        public TrackBll(IDalFactory _dalFactory)
        {
            this._dalFactory = _dalFactory;
        }
    }
}
