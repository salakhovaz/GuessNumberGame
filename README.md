Single Responsibility Principle
Каждая часть системы выполняет только одну задачу:
Класс GuessNumberGameController отвечает за управление игрой.
Интерфейс ISecretNumberGenerator и его реализации отвечают за генерацию.
Класс GameSettings используется для хранения состояния игры.

Open/Closed Principle
Открыт для расширения, но закрыт для изменения:
Можно добавлять новые способы генерации чисел благодаря внедрение интерфейса ISecretNumberGenerator, не изменяя существующий код


Liskov Substitution Principle
Классы-наследники должны быть взаимозаменяемы с родительскими классами или интерфейсами:
FixedSecretNumberGenerator и RandomSecretNumberGenerator могут использоваться вместо интерфейса ISecretNumberGenerator

Interface Segregation Principle
ISecretNumberGenerator минимален и содержит только один метод Generate - интерфейс специализирован и отвечает только за конкретную логику

Dependency Inversion Principle:
GuessNumberGameController не зависит от какой то конкретной реализации, а использует интерфейс ISecretNumberGenerator. Уже конкретная реализация внедряется через DI
