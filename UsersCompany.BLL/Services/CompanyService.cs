﻿using AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using UsersCompanies.Domain.Entities;
using UsersCompanies.Domain.DTO;
using UsersCompanies.Domain.Repositories;
using UsersCompanies.Domain.Services;

namespace UsersCompanies.BLL.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompanyDTO>> GetCompaniesAsync()
        {
            var companies = await _unitOfWork.Companies.GetCompaniesAsync();
            return _mapper.Map<IEnumerable<CompanyDTO>>(companies);
        }

        public async Task<CompanyDTO> GetCompanyByIdAsync(int companyId)
        {
            var company = await _unitOfWork.Companies.GetCompanyByIdAsync(companyId);
            return _mapper.Map<CompanyDTO>(company);
        }

        public async Task CreateCompanyAsync(CompanyDTO companyDTO)
        {
            var company = _mapper.Map<Company>(companyDTO);
            await _unitOfWork.Companies.CreateCompanyAsync(company);
        }

        public async Task UpdateCompanyAsync(CompanyDTO companyDTO)
        {
            var existingCompany = await _unitOfWork.Companies.GetCompanyByIdAsync(companyDTO.Id);

            if (existingCompany == null)
            {
                // Handling the situation if a company with the specified ID is not found
                throw new ValidationException("Company not found");
            }

            _mapper.Map(companyDTO, existingCompany);

            await _unitOfWork.Companies.UpdateCompanyAsync(existingCompany);
        }

        public async Task DeleteCompanyAsync(int companyId)
        {
            await _unitOfWork.Companies.DeleteCompanyAsync(companyId);
        }

        public async Task<IEnumerable<UserDTO>> GetUsersByCompanyIdAsync(int companyId)
        {
            var users = await _unitOfWork.Companies.GetUsersByCompanyIdAsync(companyId);
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<IEnumerable<JobDTO>> GetJobsByCompanyIdAsync(int companyId, string order)
        {
            var jobs = await _unitOfWork.Companies.GetJobsByCompanyIdAsync(companyId, order);
            return _mapper.Map<IEnumerable<JobDTO>>(jobs);
        }
    }
}
