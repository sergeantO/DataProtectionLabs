# MVPBase

Как теперь ЭТО использовать?

# Добавление новой формы сводится к следующим шагам:
1. Пишем интерфейс Представления, интерфейс Модели (если требуется).
2. Реализуем Представителя, попутно решив, будем ли мы в него передавать какие-то данные или модель.
3. [Опционально] Пишем тесты для Представителя, убеждаемся, что все нормально.
4. [Опционально] Реализуем Модель и тесты для нее.
5. Накидываем формочки и реализуем интерфейс Представления.

Смена IoC-контейнера на ваш любимый происходит путем реализации простого интерфейса IContainer классом-адаптером.

# Событие View 

-В конструкторе-

btnLogin.Click += (sender, args) => Invoke(SomeAction);
...

- Далее -

public event Action SomeAction;
private void Invoke(Action SomeAction)
{
    if (SomeAction != null) SomeAction();
}

# Событие Presenter

-В конструкторе-

View.SomeAction += () => SomeAction(View.Username, View.Password);
        

private void SomeAction(string username, string password)
{
...
}
        

# Открытие немодального окна

## Первое окно:

```
public new void Show()
{
	_context.MainForm = this;
	Application.Run(_context);
}
```

## Все остальные:

```
public new void Show()
{
    _context.MainForm = this;
    base.Show();
}
```

## Открытие модального окна:

Единственное отличие этой формы от остальных - она не главная, поэтому форме для показа не требуется ApplicationContext
```
public new void Show()
{
    ShowDialog();
}
```

Если необходимо открыть обычное окно, метод вообще не требуется определять, так как он уже реализован в классе Form.