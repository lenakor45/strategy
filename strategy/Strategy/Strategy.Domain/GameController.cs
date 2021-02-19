using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Strategy.Domain.Models;

namespace Strategy.Domain
{
    /// <summary>
    /// Контроллер хода игры.
    /// </summary>
    public class GameController
    {
        private readonly Map _map;

        // Очки жизни каждого юнита.
        private readonly Dictionary<object, int> _hp = new Dictionary<object, int>();

        private readonly ImageSource _archerSource = BuildSourceFromPath("Resources/Units/Archer.png");
        private readonly ImageSource _catapultSource = BuildSourceFromPath("Resources/Units/Catapult.png");
        private readonly ImageSource _horsemanSource = BuildSourceFromPath("Resources/Units/Horseman.png");
        private readonly ImageSource _swordsmanSource = BuildSourceFromPath("Resources/Units/Swordsman.png");
        private readonly ImageSource _deadUnitSource = BuildSourceFromPath("Resources/Units/Dead.png");
        private readonly ImageSource _grassSource = BuildSourceFromPath("Resources/Ground/Grass.png");
        private readonly ImageSource _waterSource = BuildSourceFromPath("Resources/Ground/Water.png");

        /// <inheritdoc />
        public GameController(Map map)
        {
            _map = map;
        }


        /// <summary>
        /// Получить координаты объекта.
        /// </summary>
        /// <param name="o">Координаты объекта, которые необходимо получить.</param>
        /// <returns>Координата x, координата y.</returns>
        public Coordinates GetObjectCoordinates(object o)
        {
            if (o is Unit u)
            {
                return new Coordinates(u.X, u.Y);
            }

            if (o is Ground g)
            {
                return new Coordinates(g.X, g.Y);
            }

            throw new ArgumentException("Неизвестный тип");
        }

        /// <summary>
        /// Может ли юнит передвинуться в указанную клетку.
        /// </summary>
        /// <param name="u">Юнит.</param>
        /// <param name="x">Координата X клетки.</param>
        /// <param name="y">Координата Y клетки.</param>
        /// <returns>
        /// <see langvalue="true" />, если юнит может переместиться
        /// <see langvalue="false" /> - иначе.
        /// </returns>
        public bool CanMoveUnit(object obj, int x, int y)
        {
            if (obj is Unit selectedUnit)
            {
                if (Math.Abs(selectedUnit.X - x) > selectedUnit.Step || Math.Abs(selectedUnit.Y - y) > selectedUnit.Step)
                    return false;
            }
            
            else
                throw new ArgumentException("Неизвестный тип");

            foreach (object g in _map.Ground)
            {
                if (g is Water w && w.X == x && w.Y == y)
                {
                    return false;
                }
            }

            foreach (object unit in _map.Units)
            {
                if (unit is Unit un1)
                {
                    if (un1.X == x && un1.Y == y)
                        return false;
                }
                else
                throw new ArgumentException("Неизвестный тип");
            }

            return true;
        }

        /// <summary>
        /// Передвинуть юнита в указанную клетку.
        /// </summary>
        /// <param name="u">Юнит.</param>
        /// <param name="x">Координата X клетки.</param>
        /// <param name="y">Координата Y клетки.</param>
        public void MoveUnit(object obj, int x, int y)
        {
            if (!CanMoveUnit(obj, x, y))
                return;

            if (obj is Unit unit)
            {
                unit.X = x;
                unit.Y = y;
            }

            else
                throw new ArgumentException("Неизвестный тип");
        }

        /// <summary>
        /// Проверить, может ли один юнит атаковать другого.
        /// </summary>
        /// <param name="au">Юнит, который собирается совершить атаку.</param>
        /// <param name="tu">Юнит, который является целью.</param>
        /// <returns>
        /// <see langvalue="true" />, если атака возможна
        /// <see langvalue="false" /> - иначе.
        /// </returns>
        public bool CanAttackUnit(object au, object tu)
        {
            var cr = GetObjectCoordinates(tu);
            Player ptu;
            if (tu is Unit unit)
            {
                ptu = unit.Player;
            }
            else
                throw new ArgumentException("Неизвестный тип");

            if (IsDead(tu))
                return false;

            if (au is Unit atUnit)
            {
                if (atUnit.Player == ptu)
                    return false;

                var dx = atUnit.X - cr.X;
                var dy = atUnit.Y - cr.Y;

                return dx >= -(atUnit.Attac) && dx <= atUnit.Attac && dy >= -(atUnit.Attac) && dy <= atUnit.Attac;
            }

            throw new ArgumentException("Неизвестный тип");
        }

        /// <summary>
        /// Атаковать указанного юнита.
        /// </summary>
        /// <param name="au">Юнит, который собирается совершить атаку.</param>
        /// <param name="tu">Юнит, который является целью.</param>
        public void AttackUnit(object au, object tu)
        {
            if (!CanAttackUnit(au, tu))
                return;

            InitializeUnitHp(tu);
            var thp = _hp[tu];
            var cr = GetObjectCoordinates(tu);
            int d;

            if (au is Unit unit)
            {
                d = unit.Damage;
                if (unit.Attac > 1)
                {
                    
                    var dx = unit.X - cr.X;
                    var dy = unit.Y - cr.Y;

                    if ((dx == -1 || dx == 0 || dx == 1) &&
                        (dy == -1 || dy == 0 || dy == 1))
                    {
                        d /= 2;
                    }
                }
            }
            
            else
                throw new ArgumentException("Неизвестный тип");

            _hp[tu] = Math.Max(thp - d, 0);
        }

        /// <summary>
        /// Получить изображение объекта.
        /// </summary>
        public ImageSource GetObjectSource(object o)
        {
            if (o is Archer)
            {
                if (IsDead(o))
                    return _deadUnitSource;

                return _archerSource;
            }

            if (o is Catapult)
            {
                if (IsDead(o))
                    return _deadUnitSource;

                return _catapultSource;
            }

            if (o is Horseman)
            {
                if (IsDead(o))
                    return _deadUnitSource;

                return _horsemanSource;
            }

            if (o is Swordsman)
            {
                if (IsDead(o))
                    return _deadUnitSource;

                return _swordsmanSource;
            }

            if (o is Grass)
            {
                return _grassSource;
            }

            if (o is Water)
            {
                return _waterSource;
            }

            throw new ArgumentException("Неизвестный тип");
        }

        /// <summary>
        /// Проверить, что указанный юнит умер.
        /// </summary>
        /// <param name="u">Юнит.</param>
        /// <returns>
        /// <see langvalue="true" />, если у юнита не осталось очков здоровья,
        /// <see langvalue="false" /> - иначе.
        /// </returns>
        private bool IsDead(object u)
        {
            if (_hp.TryGetValue(u, out var hp))
                return hp == 0;

            InitializeUnitHp(u);
            return false;
        }

        /// <summary>
        /// Инициализировать здоровье юнита.
        /// </summary>
        /// <param name="u">Юнит.</param>
        private void InitializeUnitHp(object u)
        {
            if (_hp.ContainsKey(u))
                return;

            if (u is Archer)
            {
                _hp.Add(u, 50);
            }
            else if (u is Catapult)
            {
                _hp.Add(u, 70);
            }
            else if (u is Horseman)
            {
                _hp.Add(u, 200);
            }
            else if (u is Swordsman)
            {
                _hp.Add(u, 100);
            }
            else
                throw new ArgumentException("Неизвестный тип");
        }

        /// <summary>
        /// Получить изображение по указанному пути.
        /// </summary>
        private static ImageSource BuildSourceFromPath(string path)
        {
            return new BitmapImage(new Uri(path, UriKind.Relative));
        }
    }
}