namespace TaskManager.Core.Constants;

public static class Messages
{
    public const string TaskNotFound = "Nenhuma tarefa encontrada";
    public const string TaskFetchFailed = "Falha ao buscar tarefa";

    public const string TaskCreatedSuccessfully = "Tarefa criada com sucesso";
    public const string TaskCreationFailed = "Falha ao criar tarefa";

    public const string TaskUpdatedSuccessfully = "Tarefa atualizada com sucesso";
    public const string TaskUpdateFailed = "Falha ao atualizar tarefa";

    public const string TaskDeletedSuccessfully = "Tarefa deletada com sucesso";
    public const string TaskDeletionFailed = "Falha ao deletar tarefa";

    public const string TaskAlreadyExists = "Tarefa já existe";

    public const string UserNotFound = "Usuário não encontrado";
    public const string UserAlreadyExists = "Usuário já cadastrado";

    public const string UserCreatedSucessfully = "Usuário criado com sucesso";
    public const string UserCreationFailed = "Falha ao criar usuário";

    public const string UserOrPasswordInvalid = "Usuário ou senha inválido.";

    public const string EmailRequired = "O e-mail é obrigatório.";
    public const string PasswordRequired = "A senha é obrigatória.";

    public const string EmailInvalid = "Email inválido";
    public const string EmailMaxLength = "O e-mail não pode exceder {0} caracteres.";

    public const string NameRequired = "O nome é obrigatório.";
    public const string NameLength = "O nome deve ter entre 3 e 100 caracteres.";

    public const string PasswordRules = "A senha deve conter pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial.";

    public const string TaskTitleRequired = "O título da tarefa é obrigatório.";
    public const string TaskTitleLength = "O título deve ter entre 3 e 100 caracteres.";

    public const string TaskDescriptionMaxLength = "A descrição não pode exceder 500 caracteres.";

    public const string TaskIdRequired = "O Id da tarefa é obrigatório.";

    public const string TaskStatusInvalid = "O status informado é inválido.";
}
