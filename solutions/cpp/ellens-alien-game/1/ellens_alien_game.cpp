namespace targets {

    class Alien {
    public:
        Alien(int x_coordinate, int y_coordinate)
            : x_coordinate(x_coordinate), y_coordinate(y_coordinate) {
            // constructor body — runs after members are initialized
        }

        int health = 3;

        int x_coordinate;
        int y_coordinate;

        int get_health() const {
            return health;
        }

       bool hit() {
            const int dmg = 1;
            if (health - dmg < 0)
                health = 0;
            else
                health -= dmg;
            return true;
        }

        bool is_alive() const {
            return health > 0;
        }

        bool teleport( const int x, const int y ) {
            x_coordinate = x;
            y_coordinate = y;
            return true;
        }

        bool collision_detection(Alien& alien) const {
            if (x_coordinate == alien.x_coordinate) {
                return true;
            }
            if (y_coordinate == alien.y_coordinate) {
                return true;
            }
            return false;

        }



    };
}  // namespace targets
