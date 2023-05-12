using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to Uganda.");

            var botClient = new TelegramBotClient("6077328740:AAFECZJcgPLsIi1ffS0ZXCv8q5vfNh9BH-0");

            using CancellationTokenSource cts = new();

            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };

            botClient.StartReceiving(
              updateHandler: HandleUpdateAsync,
              pollingErrorHandler: HandlePollingErrorAsync,
              receiverOptions: receiverOptions,
              cancellationToken: cts.Token
            );

            var me = await botClient.GetMeAsync();

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            cts.Cancel();
        }

        static async Task HandleUpdateAsync(ITelegramBotClient botclient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is not { } message)
                return;

            if (message.Text is not { } messageText)
                return;

            var chatId = message.Chat.Id;

            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");


            if (message.Text == "УгаБуга")
            {
                await botclient.SendTextMessageAsync(
                  chatId: chatId,
                  text: "БугаУга",
                  cancellationToken: cancellationToken
                );
            }

            if (message.Text == "Ящеры")
            {
                await botclient.SendTextMessageAsync(
                  chatId: chatId,
                  text: $"Да {message.From.Username}, ящеры будут сосать",
                  cancellationToken: cancellationToken
                );
            }
            
            if ( message.Text == "Война")
            {
                await botclient.SendPhotoAsync(
                chatId: chatId,
                photo: InputFile.FromUri("https://i.ytimg.com/vi/kMeu3VfMM0Y/hq720.jpg?sqp=-oaymwE7CK4FEIIDSFryq4qpAy0IARUAAAAAGAElAADIQj0AgKJD8AEB-AH-CYAC0AWKAgwIABABGH8gOSg5MA8=&rs=AOn4CLClLiHhF3zzFJdZr78FE4rqEOiS7A"),
                parseMode: ParseMode.Html,
                cancellationToken: cancellationToken
                );
            }

            if (message.Text == "Видео")
            {
                await botclient.SendVideoAsync(
                chatId: chatId,
                video: InputFile.FromUri("https://rr6---sn-jvhnu5g-c35d.googlevideo.com/videoplayback?expire=1683892616&ei=KNVdZKSFDvWQp-oPhOSK6A8&ip=188.213.34.103&id=o-AF7te6dItg0WbEwiPdJbt_9uOFW5yJQdK6APqIywWh3f&itag=18&source=youtube&requiressl=yes&spc=qEK7B1RcpzjqodJ0kFP8MlrXVNU6gSNHfDQB4DpOmA&vprv=1&svpuc=1&mime=video%2Fmp4&ns=3RZUbhxWekz3gr2x_tw8dNIN&gir=yes&clen=3216325&ratebypass=yes&dur=41.322&lmt=1681489364480715&fexp=24007246&c=WEB&txp=6310224&n=FtJ_x23h80XTOw&sparams=expire%2Cei%2Cip%2Cid%2Citag%2Csource%2Crequiressl%2Cspc%2Cvprv%2Csvpuc%2Cmime%2Cns%2Cgir%2Cclen%2Cratebypass%2Cdur%2Clmt&sig=AOq0QJ8wRQIgFSGqi53Cfp5oj7aTL0bZVB-LTE4-KiE75kYmSTbqOxMCIQDOO-dgtmjufJNj5PLESqG-U9UYoiLYwBuivG9fikJBzg%3D%3D&redirect_counter=1&rm=sn-aigedl76&req_id=ae721db3297ca3ee&cms_redirect=yes&ipbypass=yes&mh=Fs&mip=94.29.124.119&mm=31&mn=sn-jvhnu5g-c35d&ms=au&mt=1683879663&mv=m&mvi=6&pcm2cms=yes&pl=18&lsparams=ipbypass,mh,mip,mm,mn,ms,mv,mvi,pcm2cms,pl&lsig=AG3C_xAwRAIgEENJv6lKAULfFD-bMWmiTDZ8OzhuijQ8ICi1FM_U75gCIFPCKy4mN6mJycmdkvea03qQ7i2sZUu7NPywwqOzVzn-"),
                supportsStreaming: true,
                cancellationToken: cancellationToken
                );
            }
            
            if (message.Text == "Стикер")
            {
                await botclient.SendStickerAsync(
                chatId: chatId,
                sticker: InputFile.FromFileId("CAACAgIAAxkBAAEg-FdkXfnnTIbRJMbhqn27Srdv7J_15gACySgAAuJlaEkIISfGwmWlJC8E"),
                cancellationToken: cancellationToken
                );
            }
            
            if (message.Text == "Кнопки")
            {
                ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
                {
                    new KeyboardButton[] { "Who" },
                    new KeyboardButton[] { "Knows" },
                })
                {
                    ResizeKeyboard = true
                };

                await botclient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "Choose a response",
                    replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken
                    );
            }    

            if (message.Text == "Убить кнопки")
            {
                await botclient.SendTextMessageAsync(
                chatId: chatId,
                text: "Ладно",
                replyMarkup: new ReplyKeyboardRemove(),
                cancellationToken: cancellationToken);
            }    
        }

        static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                  => $"Telegram API Error:\n[{apiRequestException.ErrorCode}\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}