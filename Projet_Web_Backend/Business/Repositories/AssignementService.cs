using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class AssignementService : IAssignementService
    {
        private readonly IAssignementRepository _assignementRepository;
        IMapper _mapper;
        public AssignementService(IAssignementRepository assignementRepository, IMapper mapper)
        {
            _assignementRepository = assignementRepository;
            _mapper = mapper;
        }
        public Task<Assignment> AddAsync(AssignementCreateDTO assignement)
        {
            var assignementToAdd = _mapper.Map<Assignment>(assignement);
            return _assignementRepository.AddAsync(assignementToAdd);
        }

        public async Task<AssignementReadDTO> DeleteAsync(int assignementId)
        {
            var assignement = await _assignementRepository.DeleteAsync(assignementId);
            if(assignement == null)
            {
                throw new KeyNotFoundException("Assignement non trouvé avec l'ID spécifié.");
            }
            return _mapper.Map<AssignementReadDTO>(assignement);
        }

        public async Task<IEnumerable<AssignementReadDTO>> GetAllAsync()
        {
            var assignements = await _assignementRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AssignementReadDTO>>(assignements);
        }

        public async Task<AssignementReadDTO> GetByIdAsync(int id)
        {
            var assignement = await _assignementRepository.GetByIdAsync(id);
            return _mapper.Map<AssignementReadDTO>(assignement);
        }

        public async Task<IEnumerable<AssignementReadDTO>> GetByCourseIdAsync(int courseId)
        {
            var assignements = await _assignementRepository.GetByCourseIdAsync(courseId);
            return _mapper.Map<IEnumerable<AssignementReadDTO>>(assignements);
        }

        public async Task<AssignementReadDTO> SearchByTitleAsync(string title)
        {
            var assignement = await _assignementRepository.SearchByTitleAsync(title);
            return _mapper.Map<AssignementReadDTO>(assignement);
        }

        public async Task UpdateAsync(AssignementUpdateDTO assignement)
        {
            var existingAssignement = await _assignementRepository.GetByIdAsync(assignement.Id);
            if (existingAssignement == null)
            {
                throw new KeyNotFoundException("Assignement non trouvé avec l'ID spécifié.");
            }
            if (existingAssignement.Id == assignement.Id)
            {
                var assignementToUpdate = _mapper.Map<Assignment>(assignement);
                assignementToUpdate.CourseId = existingAssignement.CourseId;
                await _assignementRepository.UpdateAsync(assignementToUpdate);
            }
        }
    }
}
