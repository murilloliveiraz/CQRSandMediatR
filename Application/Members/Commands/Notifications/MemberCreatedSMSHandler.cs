using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Members.Commands.Notifications
{
    public class MemberCreatedSMSHandler : INotificationHandler<MemberCreatedNotification>
    {
        private readonly ILogger<MemberCreatedSMSHandler>? _logger;

        public MemberCreatedSMSHandler(ILogger<MemberCreatedSMSHandler>? logger)
        {
            _logger = logger;
        }

        public Task Handle(MemberCreatedNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Confirmation SMS sent for: {notification.Member.Email}");
            return Task.CompletedTask;
        }
    }
}
