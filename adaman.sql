-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Апр 26 2021 г., 09:43
-- Версия сервера: 8.0.19
-- Версия PHP: 7.4.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `adaman`
--

-- --------------------------------------------------------

--
-- Структура таблицы `eatery`
--

CREATE TABLE `eatery` (
  `id` int NOT NULL,
  `product` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `price` double NOT NULL,
  `quantity` int NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `eatery`
--

INSERT INTO `eatery` (`id`, `product`, `price`, `quantity`) VALUES
(1, 'Некст', 50.25, 50);

-- --------------------------------------------------------

--
-- Структура таблицы `health`
--

CREATE TABLE `health` (
  `id` int NOT NULL,
  `product` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `price` double NOT NULL,
  `quantity` int NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `health`
--

INSERT INTO `health` (`id`, `product`, `price`, `quantity`) VALUES
(1, 'Фарингосепт', 56.5, 75),
(2, 'Глицин', 50, 25);

-- --------------------------------------------------------

--
-- Структура таблицы `medprod`
--

CREATE TABLE `medprod` (
  `id` int NOT NULL,
  `product` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `price` double NOT NULL,
  `quantity` int NOT NULL,
  `fullPrice` double NOT NULL,
  `provider` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `potion`
--

CREATE TABLE `potion` (
  `id` int NOT NULL,
  `product` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `price` double NOT NULL,
  `quantity` int NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `potion`
--

INSERT INTO `potion` (`id`, `product`, `price`, `quantity`) VALUES
(1, 'Смекта', 43.75, 100),
(2, 'Агомелатин', 95.4, 100);

-- --------------------------------------------------------

--
-- Структура таблицы `products`
--

CREATE TABLE `products` (
  `id` int NOT NULL,
  `product` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `price` double NOT NULL,
  `quantity` int NOT NULL,
  `fullPrice` double NOT NULL,
  `provider` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `products`
--

INSERT INTO `products` (`id`, `product`, `price`, `quantity`, `fullPrice`, `provider`) VALUES
(21, 'Фарингосепт', 169.5, 3, 56.5, 'health'),
(20, 'Глицин', 100, 2, 50, 'health'),
(19, 'Глицин', 200, 4, 50, 'health'),
(17, 'Некст', 50.25, 2, 100.5, 'health');

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE `users` (
  `id` int NOT NULL,
  `login` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `password` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `type` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`id`, `login`, `password`, `type`) VALUES
(1, 'admin123', 'admin123', 'admin'),
(2, 'client123', 'client123', 'client');

-- --------------------------------------------------------

--
-- Структура таблицы `warehouse`
--

CREATE TABLE `warehouse` (
  `id` int NOT NULL,
  `product` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `price` double NOT NULL,
  `quantity` int NOT NULL,
  `fullPrice` double NOT NULL,
  `provider` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `warehouse`
--

INSERT INTO `warehouse` (`id`, `product`, `price`, `quantity`, `fullPrice`, `provider`) VALUES
(16, 'Некст', 56.5, 2, 113, 'КореяФарм'),
(15, 'Некст', 56.5, 2, 113, 'КореяФарм'),
(17, 'Некст', 50.25, 2, 100.5, 'health');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `eatery`
--
ALTER TABLE `eatery`
  ADD UNIQUE KEY `id` (`id`);

--
-- Индексы таблицы `health`
--
ALTER TABLE `health`
  ADD UNIQUE KEY `id` (`id`);

--
-- Индексы таблицы `medprod`
--
ALTER TABLE `medprod`
  ADD UNIQUE KEY `id` (`id`);

--
-- Индексы таблицы `potion`
--
ALTER TABLE `potion`
  ADD UNIQUE KEY `id` (`id`),
  ADD UNIQUE KEY `product` (`product`),
  ADD UNIQUE KEY `product_2` (`product`);

--
-- Индексы таблицы `products`
--
ALTER TABLE `products`
  ADD UNIQUE KEY `id` (`id`);

--
-- Индексы таблицы `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `login` (`login`),
  ADD UNIQUE KEY `password` (`password`);

--
-- Индексы таблицы `warehouse`
--
ALTER TABLE `warehouse`
  ADD UNIQUE KEY `id` (`id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `eatery`
--
ALTER TABLE `eatery`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT для таблицы `health`
--
ALTER TABLE `health`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `medprod`
--
ALTER TABLE `medprod`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT для таблицы `potion`
--
ALTER TABLE `potion`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `products`
--
ALTER TABLE `products`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT для таблицы `users`
--
ALTER TABLE `users`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `warehouse`
--
ALTER TABLE `warehouse`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
