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

        public const string _PATH = "Resources/Units/";

        /// <inheritdoc />
        public GameController(Map map)
        {
            _map = map;
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
        public bool CanMoveUnit(Unit selectedUnit, int x, int y)
        {
            if (Math.Abs(selectedUnit.X - x) > selectedUnit.Step || Math.Abs(selectedUnit.Y - y) > selectedUnit.Step)
                return false;
            
            foreach (Ground ground in _map.Ground)
            {
                if ((ground is Water w && w.X == x && w.Y == y))
                    return false;
            }
            foreach (Unit anotherUnit in _map.Units)
            {
                if (anotherUnit.X == x && anotherUnit.Y == y)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Передвинуть юнита в указанную клетку.
        /// </summary>
        /// <param name="u">Юнит.</param>
        /// <param name="x">Координата X клетки.</param>
        /// <param name="y">Координата Y клетки.</param>
        public void MoveUnit(Unit unit, int x, int y)
        {
            if (!CanMoveUnit(unit, x, y))
                return;
            unit.X = x;
            unit.Y = y;
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
        public bool CanAttackUnit(Unit attackingUnit, Unit targetUnit)
        {
            Player player = targetUnit.Player;
            
            if (Unit.IsDead(targetUnit))
                return false;

            if (attackingUnit.Player == player)
                return false;

            var dx = attackingUnit.X - targetUnit.X;
            var dy = attackingUnit.Y - targetUnit.Y;

            return dx >= -(attackingUnit.Attac) && dx <= attackingUnit.Attac && dy >= -(attackingUnit.Attac) && dy <= attackingUnit.Attac;
            
        }

        /// <summary>
        /// Атаковать указанного юнита.
        /// </summary>
        /// <param name="au">Юнит, который собирается совершить атаку.</param>
        /// <param name="tu">Юнит, который является целью.</param>
        public void AttackUnit(Unit attackUnit, Unit targetUnit)
        {
            if (!CanAttackUnit(attackUnit, targetUnit))
                return;
            var targetUnitHp = targetUnit.Hp;
            int damage = attackUnit.Damage;

            damage = Unit.ChangeDamageLevel(attackUnit, targetUnit);
            targetUnit.Hp = Math.Max(targetUnitHp - damage, 0);
        }

        /// <summary>
        /// Получить изображение объекта.
        /// </summary>
        public ImageSource GetObjectSource(MapElement curElement)
        {          
            string currentPath = _PATH + $"{curElement.Name}.png";
            ImageSource Sourse = BuildSourceFromPath(currentPath);
            return Sourse;
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