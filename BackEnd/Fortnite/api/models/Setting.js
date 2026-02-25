const { Model, DataTypes } = require('sequelize');

module.exports = (sequelize) => {
  class Setting extends Model {}

  Setting.init
  (
        {
            vsync:
            {
                type: DataTypes.BOOLEAN,

                allowNull: false,

                defaultValue: false,
            },

            resolution:
            {
                type: DataTypes.ENUM("1920x1080", "1280x900", "800x600"),
                
                allowNull: false,

                defaultValue: "1920x1080",
            },

            fullscreen:
            {
                type: DataTypes.BOOLEAN,

                defaultValue: true,
            },

            sensitivity:
            {
                type: DataTypes.FLOAT,

                validate:
                {
                    isFloat: true,

                    min: 0.00,

                    max: 100.00,
                }
            },
            graphics:
            {
                type: DataTypes.ENUM("Low", "Medium", "High", "Ultra"),

                allowNull: false,

                defaultValue: "Medium",
            }
        },
        {
            sequelize,
            modelName: 'Setting',
            createdAt: false,
            updatedAt: false,
        }
  );

  return Setting;
};
