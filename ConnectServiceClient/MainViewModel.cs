using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace ConnectServiceClient;

public class MainViewModel : ReactiveObject
{
    private readonly GrpcService _grpcService;
    private string _greetingResult;

    public ReactiveCommand<string, string> SayHelloCommand { get; }
    
    public string GreetingResult
    {
        get => _greetingResult;
        set => this.RaiseAndSetIfChanged(ref _greetingResult, value);
    }
    public MainViewModel()
    {
        _grpcService = new GrpcService();
        SayHelloCommand = ReactiveCommand.CreateFromTask<string, string>(_grpcService.SayHello);
        
        // SayHelloCommand 실행 결과를 GreetingResult에 바인딩
        SayHelloCommand
            .ObserveOn(RxApp.MainThreadScheduler)
            .Subscribe(result => GreetingResult = result);
        
        
    }
}