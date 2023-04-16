﻿using System;
using MediatR;
using PipiApp.Api.Dtos;
using PipiApp.Model;
using PipiApp.Repositories.Base;

namespace PipiApp.Api.RequestHandlers.PersonRequests
{
	public class PutPersonLikeToiletRequest : CommandBase<PersonDto>
	{
        public Guid PublicId { get; private set; }
		public string RecordId { get; set; }

		public PutPersonLikeToiletRequest(Guid publicId, string recordId)
		{
			this.PublicId = publicId;
			this.RecordId = recordId;
		}
    }
	public class PutPersonLikeToiletRequestHandler: IRequestHandler<PutPersonLikeToiletRequest, PersonDto>
	{
        private readonly IRepository<Person> _personRepo;
        private readonly IRepository<Toilet> _toiletRepo;

        public PutPersonLikeToiletRequestHandler(IRepository<Person> personRepo, IRepository<Toilet> toiletRepo)
		{
			this._personRepo = personRepo;
            this._toiletRepo = toiletRepo;
        }

        public async Task<PersonDto> Handle(PutPersonLikeToiletRequest request, CancellationToken cancellationToken)
        {
			Person person = await _personRepo.GetAsync(person => person.PublicId==request.PublicId);
			Toilet toilet = await _toiletRepo.GetAsync(toilet => toilet.RecordId == request.RecordId);
			person.AddLikedToilet(toilet);
			_personRepo.Update(person);
			await _personRepo.SaveAsync();
			return person.ConvertToDto();
		}
    }
}

