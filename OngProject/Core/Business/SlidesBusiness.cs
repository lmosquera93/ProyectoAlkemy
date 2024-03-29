﻿using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class SlidesBusiness : ISlidesBusiness
    {

        private readonly IUnitOfWork _unitOfWork;
        public SlidesBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<bool>> Delete(int Id)
        {
          
            var response = new Response<bool>(await _unitOfWork.SlidesRepository.Delete(Id), true);
            if (!response.Data)
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.Error;
            }
                return response;
        }

        public async Task<Response<List<SlideDto>>> GetAll()
        {
            var slides = await _unitOfWork.SlidesRepository.GetAll();
            var n = SlideMapper.ToSlideDtoList(slides);
            var response = new Response<List<SlideDto>>(n);

            if (response.Data == null)
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.UnexpectedErrors;
            }

            return response;
        }

        public async Task<Response<SlideDto>> GetById(int id)
        {
            var response = new Response<SlideDto>(SlideMapper.ToSlideDto(await _unitOfWork.SlidesRepository.GetById(id)));

            
            if (response.Data == null)
            {
                response.Succeeded = false;
                response.Errors = new string[] { "Error - 404" };
                response.Message = ResponseMessage.NotFound;
            }

            return response;
        }

        public async Task<Response<bool>> Insert(InsertSlideDto slideDto)
        {
            List<Slide> listSlide = await _unitOfWork.SlidesRepository.GetAll();

            var response = new Response<bool>();

            var order = String.IsNullOrEmpty(slideDto.Order) ? (listSlide.Count() + 1).ToString() : slideDto.Order;

            response.Data = await _unitOfWork.SlidesRepository.Insert(SlideMapper.ToDtoInsertSlide(slideDto, order));

            if (!response.Data)
            {
                response.Succeeded = false;
                response.Message = ResponseMessage.Error;

            }
            return response;
        }

        public async Task<Response<bool>> Update(UpdateSlidesDto slide, int Id)
        {
            var response = new Response<bool>(false);

            var find = await _unitOfWork.SlidesRepository.GetById(Id);

            if (find == null)
            {
                response.Message = ResponseMessage.NotFoundOrDeleted;
                response.Succeeded = false;
                return response;
            }

            response.Data = await _unitOfWork.SlidesRepository.Update(SlideMapper.UpdateToSlide(slide, find));
            return response;
        }
    }
}
