# EPILOG
Editor Pretty Idle LOGger for Unity ;)

Makes Unity editor console more informative.

Делает консоль редактора Unity более информативной.

```
public void Something()
{
    Epilog.Print("Some log message");
    // or
    Epilog.Print("Yet another log message", 42, "Hi!", true, SomeObject);
    // or
    Epilog.Error("Error log message")
    // or
    Epilog.Print(LogType.Error, "Yet another log message");
}
```
Result/Результат:

![Epilog screenshot](/epilog.png)

And one more thing.

И еще. =)

It's emoji here

Тут есть емодзи

```
Epilog.Emoji.Shrug();
Epilog.Emoji.FlipTable();
...
```

![Epilog screenshot](/epilog_emoji.png)
