using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ImporterApp.DTO;
using ImporterApp.Enities;

namespace ImporterApp.Helpers
{
    public class DtoConverter
    {
        private readonly IMapper _mapper;
        public DtoConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<T> ConvertFromGeneralToDto<T>(List<General> generalList)
        {
            List<T> result = new List<T>();

            for (int i = 0; i < generalList.Count; i++)
            {
                var dtoObject = _mapper.Map<T>(generalList[i]);
                result.Add(dtoObject);
            }

            return result;
        }
    }
}
