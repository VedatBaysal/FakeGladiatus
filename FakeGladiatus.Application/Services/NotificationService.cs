using FakeGladiatus.Application.Entities;
using FakeGladiatus.Application.Entities.DbEntities;
using FakeGladiatus.Application.Repositories;
using FakeGladiatus.Application.Services.Interfaaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FakeGladiatus.Application.Manager;
using Microsoft.EntityFrameworkCore;

namespace FakeGladiatus.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IRepository<UserDbEntity> _userRepository;
        private readonly IRepository<CharacterDbEntity> _charRepository;
        private readonly IRepository<NotificationDbEntity> _notificationRepository;
        private readonly IUserService _userService;
        public NotificationService(IRepository<UserDbEntity> userRepository, IRepository<CharacterDbEntity> charRepository, IRepository<NotificationDbEntity> notificationRepository, IUserService userService)
        {
            _charRepository = charRepository;
            _userRepository = userRepository;
            _notificationRepository = notificationRepository;
            _userService = userService;
        }
        public void CreateNatificationForFight(int attackerUserId, int attackerCharId, int targetUserId, int targetCharId, string fightTime)
        {
            var notification = new NotificationDbEntity
            {
                AttackerUser = _userRepository.GetById(attackerUserId),
                AttackerChar = _charRepository.GetById(attackerCharId),
                TargetUser = _userRepository.GetById(targetUserId),
                TargetChar = _charRepository.GetById(targetCharId),
                FightTime = Convert.ToDateTime(fightTime),
                IsRead = false

            };
            _notificationRepository.Add(notification);
        }
        public IEnumerable<Notification> GetNotification(int userId)
        {

            IQueryable<Notification> n = _notificationRepository.GetAll()
                .Include(x=>x.TargetUser)
                .Include(x=>x.TargetChar)
                .Include(x=>x.AttackerChar)
                .Include(x=>x.AttackerUser)
                    .Where(x => x.TargetUser.Id == (userId) && x.IsRead == false).Select(x => x.Build());
            return n;
        }

    }
}
